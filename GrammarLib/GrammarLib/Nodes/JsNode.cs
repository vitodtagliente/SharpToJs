using Irony.Interpreter.Ast;
using Irony.Parsing;
using Irony.Ast;

namespace GrammarLib.Nodes
{
    public abstract class JsNode : AstNode
    {
        protected bool SetTailChildren()
        {
            if (ChildNodes.Count == 0)
                return false;
            ChildNodes[ChildNodes.Count - 1].Flags |= AstNodeFlags.IsTail;
            return true;
        }

        protected virtual void InitChildren(ParseTreeNodeList nodes)
        {

        }

        protected virtual void AfterInit()
        {

        }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            var nodes = treeNode.GetMappedChildNodes();
            InitChildren(nodes);
            AfterInit();
        }

        protected void InitChildrenAsList(ParseTreeNodeList nodes)
        {
            foreach (var node in nodes)
            {
                if (node.AstNode != null)
                    AddChild(string.Empty, node);
            }
        }

        public abstract void Accept(AST.INodeVistor visitor);
    }
}
