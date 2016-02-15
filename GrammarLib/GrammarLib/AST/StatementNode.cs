using System.Text;

namespace SharpToJs.AST
{
    public class StatementNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Tab);
            str.Append(base.ToJs());
            str.Append(";");
            str.AppendLine(string.Empty);
            return str.ToString();
        }
    }
}
