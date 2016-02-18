using System.Text;

namespace SharpToJs.AST
{
    public class DeclarationStatementNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.Append("var ");

            var stmts = FindChild("variable-declarations");
            var stmt = stmts.FindChild("variable-declaration");

            str.Append(stmt.FindChild<IdentifierToken>().ToJs());

            if(stmt.FindSymbolInChildren("="))
            {
                str.Append(" = ");
                var expression = stmt.FindChild("expressions");
                str.Append(expression.ToJs());
            }

            str.Append(";");

            return str.ToString();
        }
    }
}
