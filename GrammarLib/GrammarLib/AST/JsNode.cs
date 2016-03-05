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

        static StringBuilder tab = new StringBuilder();
        public static string Tab { get { return tab.ToString(); } set { tab.Append(value); } }
        
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

        public virtual void AfterInit()
        {

        }

        public void Parse()
        {
            SetChildren(Context.ChildNodes);
            BeforeBehaviour();
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
                ((JsNode)node).AfterInit();
                ((JsNode)node).Parse();
            }
        }

        public virtual void AfterBehaviour()
        {

        }

        public void SemanticCheck()
        {
            AfterBehaviour();
            foreach(var child in Children)
            {
                ((JsNode)child).SemanticCheck();
            }
        }

        public void Remove()
        {
            if (Parent != null)
                Parent.Children.Remove(this);
        }

        public void Shift()
        {
            tab.Append("\t");
        }

        public void Unshift()
        {
            if (tab.Length > 0)
                tab.Remove(tab.Length - ("\t").Length, ("\t").Length);
        }
        
        public virtual void BeforeBehaviour()
        {

        }

        public virtual string ToJs()
        {
            StringBuilder str = new StringBuilder();
            foreach (var child in Children)
            {
                str.Append(((JsNode)child).ToJs());
            }
            return str.ToString();
        }

        public bool FindSymbolInChildren(string symbol)
        {
            foreach(var child in Context.ChildNodes)
            {
                if (child.Token != null && child.Token.Text == symbol)
                    return true;
            }

            return false;
        }

        public JsNode FindChild(string name)
        {
            foreach(var child in Children)
            {
                if (((JsNode)child).Label.ToLower() == name.ToLower())
                    return ((JsNode)child);
            }
            return null;
        }

        public T FindChild<T>(bool recursive = true)
        {
            foreach(var child in Children)
            {
                if (child.GetType() == typeof(T))
                    return (T)child;
            }

            if (!recursive)
                return default(T);

            foreach(var child in Children)
            {
                var result = ((JsNode)child).FindChild<T>();
                if (result != null)
                    return (T)result;
            }
            return default(T);
        }

        public List<T> FindChildren<T>(bool recursive = true)
        {
            var list = new List<T>();

            foreach (var child in Children)
            {
                if (child.GetType() == typeof(T))
                    list.Add( (T)child );
            }

            if (!recursive)
                return list;

            foreach (var child in Children)
            {
                var result = ((JsNode)child).FindChildren<T>();
                list.AddRange(result);
            }

            return list;
        }

        public string ToPosition()
        {
            return string.Format("Line: \"{0}\", Column: \"{1}\", Position: \"{2}\" ",
                    Context.Span.Location.Line, Context.Span.Location.Column, Context.Span.Location.Position
                    );
        }
    }
}
