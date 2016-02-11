
namespace SharpToJs.AST
{
    public class KeySymbolNode : JsNode
    {
        public override void SetBehaviour()
        {
            
        }

        public override string ToJs()
        {
            return Context.Token.Text;
        }
    }
}
