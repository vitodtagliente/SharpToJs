using System.Collections.Generic;

namespace SharpToJs.ST
{  
    public class SymbolTable 
    {
        public List<Symbol> Elements { get; private set; }
        
        // access hierarchy
        SymbolStack _namespaces = new SymbolStack();
        SymbolStack _classes = new SymbolStack();

        public SymbolTable()
        {
            Elements = new List<Symbol>();
        }

        public void PushNamespace(string name)
        {
            var symbol = new Symbol(name, "namespace");
            Elements.Add(symbol);
            _namespaces.Push(symbol);
        }

        public Symbol CurrentNamespace
        {
            get
            {
                return _namespaces.Last;
            }
        }

        public void PopNamespace()
        {
            _namespaces.Pop();
        }

        public void PushClass(string name, string namespace_name)
        {
            var symbol = new Symbol(name, "class");
            symbol.Scope = namespace_name;
            Elements.Add(symbol);
            _classes.Push(symbol);
        }

        public Symbol CurrentClass
        {
            get
            {
                return _classes.Last;
            }
        }

        public void PopClass()
        {
            _classes.Pop();
        }

        public Symbol Find(string name, string category)
        {
            foreach (var elem in Elements)
            {
                if (elem.Name == name && elem.Category == category)
                    return (elem);
            }
            return null;
        }
        
        public List<Symbol> FindElements(string name, string category)
        {
            List<Symbol> list = new List<Symbol>();
            if (Find(name, category) == null)
                return list;

            foreach (var symbol in Elements)
            {
                if (symbol.Scope == name)
                    list.Add(symbol);
            }

            return list;
        }

        public List<Symbol> FindClassElements(string name)
        {
            return FindElements(name, "class");
        }
    }
}
