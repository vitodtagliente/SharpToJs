using System.Text;

namespace SharpToJs.AST
{
    public class ElseStmtNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            var block = FindChild<BlockNode>();

            if(block == null)
                str.AppendLine(string.Empty);
            str.Append(Tab);
            str.Append("else");
            str.AppendLine(string.Empty);
            
            if (block == null)
            {
                Shift();
                str.Append(Tab);
            }

            str.Append(base.ToJs());

            if(block == null)
            {
                Unshift();
            }

            var stmt = FindChild("embedded-statement");
            if(stmt != null)
            {
                if (stmt.FindChild<BlockNode>() == null)
                    str.Append(";");
            }

            return str.ToString();
        }
    }
}
