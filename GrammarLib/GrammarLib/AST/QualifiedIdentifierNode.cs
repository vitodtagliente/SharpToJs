using Irony.Parsing;

namespace GrammarLib.AST
{
    public class QualifiedIdentifierNode : JsNode
    {
        public string Value { get; private set; }

        public override void SetChildren(ParseTreeNodeList children)
        {
            string comma = string.Empty;
            for (int i = 0; i < children.Count; i++)
            {
                Value += (comma + children[i].Token.Value);
                comma = ".";
            }
        }

        public override string ToJS()
        {
            return string.Empty;
        }
    }
}
