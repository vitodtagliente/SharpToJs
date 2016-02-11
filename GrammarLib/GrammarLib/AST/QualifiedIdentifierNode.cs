
namespace GrammarLib.AST
{
    public class QualifiedIdentifierNode : JsNode
    {
        public string Value { get; private set; }

        public override void SetBehaviour()
        {
            string comma = string.Empty;
            for (int i = 0; i < Context.ChildNodes.Count; i++)
            {
                Value += (comma + Context.ChildNodes[i].Token.Value);
                comma = ".";
            }
        }

        public override string ToJs()
        {
            return string.Empty;
        }
    }
}
