using System;

namespace Ninja.FileUtil.Parser
{
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(int index, object defaultvalue = null)
        {
            Index = index;
            DefaultValue = defaultvalue;
        }

        public int Index { get; private set; }
        public object DefaultValue { get; private set; }
    }

}