using Irony.Ast;
using Irony.Parsing;

namespace GrammarLib.Nodes
{
    public class IdentifierNode : JsNode
    {
        public string Id { get; private set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Id = AsString = treeNode.Token.Text;
        }

        public override void Accept(AST.INodeVistor visitor)
        {
            visitor.Visit(this);
        }
    }
}
