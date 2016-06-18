using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Ninja.FileUtil.Configuration;

namespace Ninja.FileUtil.Parser.Impl
{
    public class LineParser<T> : ILineParser<T> where T : BaseFileLine, new()
    {
        private readonly ParserSettings settings;
        
        public LineParser(ParserSettings settings)
        {
            this.settings = settings;
        }

        public T[] Parse(string[] lines) 
        {
            var list = new List<T>();
            var objLock = new object();

           var index = 0;
          
           Parallel.ForEach(lines.Select(line => new {Line = line, Index = index++ }), 
                () => new List<T>(), (obj, loopstate, localStorage) =>
                {
                    var parsed = ParseLine(obj.Index, obj.Line);
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

        private T  ParseLine(int index, string line) 
        {
            var obj = new T();

            obj.SetIndex(index);

            var values = line.Split(settings.Delimeter);

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

            if ((settings.IsPlain && propInfos.Length != (values.Length + 1)) ||
                (!settings.IsPlain && propInfos.Length != values.Length))
            {
                obj.SetError(ErrorMessage.InvalidLengthErrorFormat);
                return obj;
            }

            SetType(obj, values[0]);
            
            foreach (var propInfo in propInfos)
            {
                try
                {
                    var attribute = (ColumnAttribute) propInfo.GetCustomAttributes(typeof (ColumnAttribute), true).First();

                    var pvalue = values[settings.IsPlain ? attribute.Index+ 1: attribute.Index];

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

        private void SetType(BaseFileLine obj, string type)
        {
            if (settings.IsPlain)
            {
                obj.SetType(LineType.Data);
                return;
            }

            if (string.IsNullOrWhiteSpace(type) ||
                (!settings.IsPlain && !type.In(settings.Header, settings.Footer, settings.Data)))
            {
                obj.SetError(ErrorMessage.InvalidTypeValueError);
                obj.SetType(LineType.Unknown);
                return;
            }

            if(type.Equals(settings.Header, StringComparison.OrdinalIgnoreCase))
                obj.SetType(LineType.Header);
            else if (type.Equals(settings.Footer, StringComparison.OrdinalIgnoreCase))
                obj.SetType(LineType.Footer);
            else if (type.Equals(settings.Data, StringComparison.OrdinalIgnoreCase))
                obj.SetType(LineType.Data);

        }

    }

    public static class Extensions
    {
        public static bool In(this string input, params string[] values)
        {
            return values != null && values.Contains(input);
        }
    }


}
