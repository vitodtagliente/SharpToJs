using System.Collections.Generic;

namespace SharpToJs.ST
{
    public class SymbolStack : Stack<Symbol>
    {
        public bool Empty
        {
            get { return Count == 0; }
        }

        public Symbol Last
        {
            get
            {
                var arr = ToArray();
                if (arr.Length > 0)
                    return arr[arr.Length - 1];
                return null;
            }
        }
    }
}
