using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Ninja.FileUtil.Parser.Impl
{
    public class LineParser : ILineParser
    {
        private readonly IDelimiter configuration;

        public LineParser(IDelimiter configuration)
        {
            this.configuration = configuration;
        }

        public T[] Parse<T>(IEnumerable<string> lines, LineType type) where T : IFileLine, new()
        {
            var list = new List<T>();
            var objLock = new object();

           var index = 0;
          
           Parallel.ForEach(lines.Select(line => new {Line = line, Index = index++ }), 
                () => new List<T>(), (obj, loopstate, localStorage) =>
                {
                    var parsed = ParseLine<T>(obj.Index, obj.Line, type);
                    localStorage.Add(parsed);
                    return localStorage;
                },

                finalStorage =>
                {
                    if (finalStorage == null) return;

                    lock (objLock)
                        list.AddRange(finalStorage);
                });

                return list.ToArray();
        }

        private T ParseLine<T>(int index, string line, LineType type) where T : IFileLine, new()
        {
            var obj = new T
            {
                Index = index,
                Type = type
            };

            var values = line.Split(configuration.Delimeter);

            if (values.Length == 0 || values.Length == 1)
            {
                obj.SetError(ErrorMessage.InvalidLineFormat);
                return obj;
            }

            var propInfos = typeof(T).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(ColumnAttribute), true).Any() && p.CanWrite)
                .ToArray();

            if(propInfos.Length == 0)
            {
                obj.SetError(string.Format(ErrorMessage.NoColumnAttributesFoundFormat, typeof(T).Name));
                return obj;
            }

            var isSimpleMode = IsSimpleMode();

            if ((isSimpleMode && propInfos.Length != (values.Length + 1)) ||
                (!isSimpleMode && propInfos.Length != values.Length))
            {
                obj.SetError(ErrorMessage.InvalidLengthErrorFormat);
                return obj;
            }
            
            foreach (var propInfo in propInfos)
            {
                try
                {
                    var attribute = (ColumnAttribute) propInfo.GetCustomAttributes(typeof (ColumnAttribute), true).First();

                    var pvalue = values[isSimpleMode ? attribute.Index + 1 : attribute.Index];

                    if (string.IsNullOrWhiteSpace(pvalue) && attribute.DefaultValue != null)
                        pvalue = attribute.DefaultValue.ToString();

                    if (propInfo.PropertyType.IsEnum)
                    {
                        if (string.IsNullOrWhiteSpace(pvalue))
                        {
                            obj.SetError(string.Format(ErrorMessage.InvalidEnumValueErrorFormat, propInfo.Name));
                            continue;
                        }

                        long enumLong;
                        if (long.TryParse(pvalue, out enumLong))
                        {
                            var numeric = Enum.ToObject(propInfo.PropertyType, enumLong);
                            propInfo.SetValue(obj, numeric, null);
                            continue;
                        }

                        var val = Enum.Parse(propInfo.PropertyType, pvalue, true);
                        propInfo.SetValue(obj, val, null);
                        continue;
                    }

                    var converter = TypeDescriptor.GetConverter(propInfo.PropertyType);
                    var value = converter.ConvertFrom(pvalue);

                    propInfo.SetValue(obj, value, null);
                }
                catch (Exception e)
                {
                    obj.SetError(string.Format(ErrorMessage.LineExceptionFormat, propInfo.Name, e.Message) );
                }
            }

            return obj;
        }

        private bool IsSimpleMode()
        {
            return !configuration.GetType().IsAssignableFrom(typeof (IFullMode));
        }
    }

    public static class Extensions
    {
        public static bool In(this string input, params string[] values)
        {
            return values != null && values.Contains(input);
        }

        public static void SetError(this IFileLine obj, string error)
        {
            obj.Errors.Add(error);
            obj.InError = true;
        }
    }
}
