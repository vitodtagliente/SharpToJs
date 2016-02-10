using Irony.Parsing;
using System.Text;
using System.Collections.Generic;

namespace GrammarLib.AST
{
    public class JsNode
    {
        public List<object> Children { get; protected set; }

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
                var node = NodeFactory.Find(child);
                if (node == null)
                    continue;
                Children.Add(node);
            }
        }

        public virtual void AfterInit()
        {

        }

        public virtual string ToJS()
        {
            StringBuilder str = new StringBuilder();
            foreach (var child in Children)
                str.AppendLine(((JsNode)child).ToJS());
            return str.ToString();
        }
    }
}
