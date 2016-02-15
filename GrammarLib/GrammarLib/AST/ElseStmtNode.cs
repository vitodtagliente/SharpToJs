using System.Text;

namespace SharpToJs.AST
{
    public class ElseStmtNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Empty);
            str.Append(Tab);
            str.Append("else");
            str.AppendLine(string.Empty);

            Shift();

            str.Append(Tab);
            str.Append(base.ToJs());

            Unshift();

            return str.ToString();
        }
    }
}
