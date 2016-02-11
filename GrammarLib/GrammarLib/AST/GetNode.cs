using System.Text;

namespace SharpToJs.AST
{
    public class GetNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("\tget: function()");
            str.Append(base.ToJs());
            return str.ToString();
        }
    }
}
