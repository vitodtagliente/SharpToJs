using Irony.Parsing;
using System.Text;
using System.Collections.Generic;

namespace SharpToJs.AST
{
    public class JsNode
    {
        public List<object> Children { get; protected set; }
        public JsNode Parent;
        public AbstractSyntaxTree AST;
        
        public ParseTreeNode Context { get; private set; }   

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

        public void Init(ParseTreeNode node)
        {
            Label = node.Term.Name;
            Context = node;
        }

        public void Parse()
        {
            SetChildren(Context.ChildNodes);
            SetBehaviour();
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
                ((JsNode)node).AST = AST;
                ((JsNode)node).Parse();
            }
        }

        public virtual void SetBehaviour()
        {

        }

        public virtual string ToJs()
        {
            StringBuilder str = new StringBuilder();
            foreach (var child in Children)
                str.Append(((JsNode)child).ToJs());
            return str.ToString();
        }

        public bool FindSymbolInChild(string symbol)
        {
            foreach(var child in Context.ChildNodes)
            {
                if (child.Token != null && child.Token.Text == symbol)
                    return true;
            }

            return false;
        }

        public T FindChild<T>()
        {
            foreach(var child in Children)
            {
                if (child.GetType() == typeof(T))
                    return (T)child;
            }

            foreach(var child in Children)
            {
                var result = ((JsNode)child).FindChild<T>();
                if (result != null)
                    return (T)result;
            }
            return default(T);
        }

        public List<T> FindChildren<T>()
        {
            var list = new List<T>();

            foreach (var child in Children)
            {
                if (child.GetType() == typeof(T))
                    list.Add( (T)child );
            }

            foreach (var child in Children)
            {
                var result = ((JsNode)child).FindChildren<T>();
                list.AddRange(result);
            }

            return list;
        }
    }
}
