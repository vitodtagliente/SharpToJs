using System.Text;

namespace SharpToJs.AST
{
    public class BlockNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("{");
            str.Append(base.ToJs());
            str.AppendLine("}");
            return str.ToString();
        }
    }
}
