
namespace SharpToJs.AST
{
    public class ObjectNode : JsNode
    {
        public string Type { get; private set; }

        public override void AfterBehaviour()
        {
            Type = string.Empty;

        }
    }
}
