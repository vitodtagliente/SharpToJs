using System.Text;

namespace SharpToJs.AST
{
    public class ForeachNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            str.Append("for ( var ");
            str.Append(FindChild<IdentifierToken>().ToJs());
            str.Append(" in ");
            str.Append(FindChild<MemberExpressionNode>().ToJs());
            str.Append(" )");

            var stmt = FindChild("embedded-statement");
            str.AppendLine(string.Empty);
            str.Append(stmt.ToJs());

            return str.ToString();
        }
    }
}
