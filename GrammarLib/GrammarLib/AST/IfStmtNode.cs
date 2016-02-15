using System.Text;

namespace SharpToJs.AST
{
    public class IfStmtNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.Append("if (");

            var expression = FindChild("expression");
            if (expression != null)
                str.Append(expression.ToJs());

            str.Append(" )");

            var stmt = FindChild("embedded-statement");
            str.AppendLine(string.Empty);

            var block = stmt.FindChild<BlockNode>();
            if (block == null)
            {
                Shift();
                str.Append(Tab);
            }

            str.Append(stmt.ToJs());

            if (block == null)
            {
                Unshift();
                str.Append(";");
            }

            var else_stmt = FindChild<ElseStmtNode>();
            if (else_stmt != null && else_stmt.IsLeaf == false)
            {
                str.Append(else_stmt.ToJs());
            }

            return str.ToString();
        }
    }
}
