using Irony.Parsing;

namespace GrammarLib.AST
{
    public class IdentifierToken : JsNode
    {
        public string Value { get; private set; }

        public override void Init(ParseTreeNode node)
        {
            base.Init(node);
            Value = node.Token.Value.ToString();
        }

        public override string ToJS()
        {
            return string.Empty;
        }
    }
}
