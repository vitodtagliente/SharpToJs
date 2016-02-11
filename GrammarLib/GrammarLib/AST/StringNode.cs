
namespace SharpToJs.AST
{
    public class StringNode : JsNode
    {
        public string Value { get; private set; }

        public override void SetBehaviour()
        {
            Value = Context.Token.Value.ToString();
        }

        public override string ToJs()
        {
            return string.Empty;
        }
    }
}
