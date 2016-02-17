using System.Collections.Generic;

namespace SharpToJs.AST
{
    public class Symbol
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Symbol(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    public class SymbolTable : Stack<Symbol>
    {
        public List<string> PublicMembers = new List<string>();
 
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
