using System.Text;

namespace SharpToJs.AST
{
    public class WhileNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            str.Append("while ( ");

            var expr = FindChild("expression");
            str.Append(expr.ToJs());

            str.Append(" )");

            str.AppendLine(string.Empty);

            var stmt = FindChild("embedded-statement");
            str.Append(stmt.ToJs());

            return str.ToString();
        }
    }
}
