using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Ninja.FileUtil.Configuration;
using Ninja.FileUtil.Properties;

namespace Ninja.FileUtil.Parser.Impl
{
    internal class LineParser : ILineParser
    {
        private readonly IDelimiter configuration;

        public LineParser(IDelimiter configuration)
        {
            this.configuration = configuration;
        }

        public T[] Parse<T>(string[] lines, LineType type) where T : IFileLine, new()
        {
            var list = new List<T>();
           
            if (lines == null || lines.Length == 0) return list.ToArray();

            // list.AddRange(ParseMultiThread<T>(lines, type));
            list.AddRange(ParseSequemtial<T>(lines, type));

            return list.ToArray();
        }

        private List<T> ParseSequemtial<T>(string[] lines, LineType type) where T : IFileLine, new()
        {
            var list = new List<T>();

            var objLock = new object();

            var index = 0;
            var inputs = lines.Select(line => new { Line = line, Index = index++ });

            foreach (var obj in inputs)
            {
                var parsed = ParseLine<T>(obj.Index, obj.Line, type);
                list.Add(parsed);
            }

            return list;
        }

        private List<T> ParseMultiThread<T>(string[] lines, LineType type) where T : IFileLine, new()
        {
            var list = new List<T>();

            var objLock = new object();

            var index = 0;
            var inputs = lines.Select(line => new { Line = line, Index = index++ });

            Parallel.ForEach(inputs, () => new List<T>(),
                (obj, loopstate, localStorage) =>
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

            return list;
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
                obj.SetError(Resources.InvalidLineFormat);
                return obj;
            }

            var propInfos = typeof(T).GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(ColumnAttribute), true).Any() && p.CanWrite)
                .ToArray();

            if (propInfos.Length == 0)
            {
                obj.SetError(string.Format(Resources.NoColumnAttributesFoundFormat, typeof(T).Name));
                return obj;
            }

            var isSimpleMode = configuration.IsSimpleMode();

            if ((isSimpleMode && propInfos.Length != (values.Length)) ||
                (!isSimpleMode && propInfos.Length + 1 != values.Length))
            {
                obj.SetError(Resources.InvalidLengthErrorFormat);
                return obj;
            }

            foreach (var propInfo in propInfos)
            {
                try
                {
                    var attribute = (ColumnAttribute)propInfo.GetCustomAttributes(typeof(ColumnAttribute), true).First();

                    var pvalue = values[isSimpleMode ? attribute.Index : attribute.Index + 1];

                    if (string.IsNullOrWhiteSpace(pvalue) && attribute.DefaultValue != null)
                        pvalue = attribute.DefaultValue.ToString();

                    if (propInfo.PropertyType.IsEnum)
                    {
                        if (string.IsNullOrWhiteSpace(pvalue))
                        {
                            obj.SetError(string.Format(Resources.InvalidEnumValueErrorFormat, propInfo.Name));
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
                    obj.SetError(string.Format(Resources.LineExceptionFormat, propInfo.Name, e.Message));
                }
            }

            return obj;
        }
    }


}
