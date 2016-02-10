using Irony.Parsing;
using Irony.Interpreter;
using Irony.Ast;
using Irony.Interpreter.Ast;

namespace GrammarLib
{
    public class MathNode : Irony.Interpreter.Ast.AstNode
    {
        public MathNode()
        {

        }

        protected virtual void InitChildren(ParseTreeNodeList nodes)
        {

        }

        protected virtual void AfterInit(ParseTreeNodeList nodes)
        {

        }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            var nodes = treeNode.GetMappedChildNodes();
            InitChildren(nodes);
            AfterInit(nodes);
        }

        protected void InitChildrenAsList(ParseTreeNodeList nodes)
        {
            foreach (var child in nodes)
            {
                if (child.AstNode != null)
                    AddChild(string.Empty, child);
            }
        }

    }

    public class ProgramExpression : MathNode
    {
        protected override void AfterInit(ParseTreeNodeList nodes)
        {
            foreach (var child in nodes)
            {
                if (child.AstNode == null && child.ChildNodes.Count > 0)
                    AddChild("expr", child.ChildNodes[0]);
            }
        }
    }
    
    public class BinExpression : MathNode
    {
        public AstNode Left, Right;
        public string Operator;

        protected override void AfterInit(ParseTreeNodeList nodes)
        {
            AsString = "BinExpression";
            Left = AddChild("Arg", nodes[0]);
            Right = AddChild("Arg", nodes[2]);

            Operator = nodes[1].FindToken().Text;
        }
    }
}
