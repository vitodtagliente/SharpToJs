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

            var stmt = FindChild("embedded-statement");
            if (stmt != null)
            {
                var control_flow = stmt.FindChild("control-flow-statement");
                if (control_flow == null && IsLeaf == false)
                    str.Append(";");
            }
            else str.Append(";");

            str.AppendLine(string.Empty);
            return str.ToString();
        }
    }
}
