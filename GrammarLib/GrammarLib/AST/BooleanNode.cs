
namespace SharpToJs.AST
{
    public class BooleanNode : JsNode
    {
        public string Value { get; private set; }

        public override void BeforeBehaviour()
        {
            Value = string.Empty;
            if (Context.ChildNodes.Count > 0)
            {
                Value = Context.ChildNodes[0].Token.Text;
            }
        }

        public override string ToJs()
        {
            return Value;
        }
    }
}
