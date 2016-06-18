using System.Collections.Generic;
using System.Linq;
using Ninja.FileUtil.Parser;

namespace Ninja.FileUtil
{
    public abstract class BaseFileLine : IFileLine
    {
        protected BaseFileLine()
        {
            Errors = new List<string>();
        }

        public int Index { get; private set; }
        public bool InError { get { return Errors.Any(); } }
        public IList<string> Errors { get; private set; }
        public LineType Type { get; private set; }

        internal void SetError(string error)
        {
            Errors.Add(error);
        }
        internal void SetIndex(int index)
        {
            Index = index;
        }
        internal void SetType(LineType type)
        {
            Type = type;
        }
    }
}
