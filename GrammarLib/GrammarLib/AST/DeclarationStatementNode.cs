using System.Text;

namespace SharpToJs.AST
{
    public class DeclarationStatementNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.Append("var ");

            str.Append(FindChild<IdentifierToken>().ToJs());

            if(FindSymbolInChildren("="))
            {
                str.Append(" = ");
                var expression = FindChild("expressions");
                str.Append(expression.ToJs());
            }

            str.Append(";");

            return str.ToString();
        }
    }
}
