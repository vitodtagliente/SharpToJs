using System.Text;

namespace SharpToJs.AST
{
    public class DoNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.Append("do");
            str.AppendLine(string.Empty);
                        
            var stmt = FindChild("embedded-statement");
            str.Append(stmt.ToJs());
                        
            str.Append(Tab);
            str.Append("while ( ");

            var expr = FindChild("expression");
            str.Append(expr.ToJs());

            str.Append(" );");

            return str.ToString();
        }
    }
}
