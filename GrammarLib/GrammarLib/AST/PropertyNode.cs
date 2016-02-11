using System.Text;

namespace SharpToJs.AST
{
    public class PropertyNode : JsNode
    {
        IdentifierToken id;

        public override void SetBehaviour()
        {
            id = FindChild<IdentifierToken>();

        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            return str.ToString();
        }
    }
}
