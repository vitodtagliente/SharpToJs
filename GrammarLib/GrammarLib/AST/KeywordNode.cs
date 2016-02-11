
namespace SharpToJs.AST
{
    public class KeywordNode : JsNode
    {
        public string Value { get; private set; }

        public override void SetBehaviour()
        {
            Value = string.Empty;
            if(Context.ChildNodes.Count > 0)
            {
                Value = Context.ChildNodes[0].Token.Text;
            }
        }

        public override string ToJs()
        {
            return string.Empty;
        }
    }
}
