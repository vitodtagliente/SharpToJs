using Irony.Parsing;
using System.Text;
using System.Collections.Generic;

namespace GrammarLib.AST
{
    public class JsNode
    {
        public List<object> Children { get; protected set; }
        public JsNode Parent;
        public static SymbolTable Table = new SymbolTable();
        static StringBuilder strErrors = new StringBuilder();
        public static string Errors
        {
            get { return strErrors.ToString(); }
            private set { strErrors.AppendLine(value); }
        }

        public bool IsRoot
        {
            get { return Parent == null; }
        }

        public bool IsLeaf
        {
            get { return Children.Count == 0; }
        }

        public string Label { get; set; }

        public JsNode()
        {
            Children = new List<object>();
        }

        public virtual void Init(ParseTreeNode node)
        {
            Label = node.Term.Name;
            SetChildren(node.ChildNodes);
            AfterInit();
        }

        public virtual void SetChildren(ParseTreeNodeList children)
        {
            foreach(var child in children)
            {
                var node = NodeFactory.Map(child);
                if (node == null)
                    continue;
                Children.Add(node);
                ((JsNode)node).Parent = this;
            }
        }

        public virtual void AfterInit()
        {

        }

        public virtual string ToJS()
        {
            StringBuilder str = new StringBuilder();
            foreach (var child in Children)
                str.Append(((JsNode)child).ToJS());
            return str.ToString();
        }

        public T FindInChildren<T>()
        {
            foreach(var child in Children)
            {
                if (child.GetType() == typeof(T))
                    return (T)child;
            }

            foreach(var child in Children)
            {
                var result = ((JsNode)child).FindInChildren<T>();
                if (result != null)
                    return (T)result;
            }
            return default(T);
        }
    }
}
