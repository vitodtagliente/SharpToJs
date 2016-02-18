using System.Text;

namespace SharpToJs.AST
{
    public class ObjectCreationNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.Append("new ");
            str.Append(base.ToJs());
            return str.ToString();
        }
    }
}
