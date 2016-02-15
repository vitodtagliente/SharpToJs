using System.Text;

namespace SharpToJs.AST
{
    public class ReturnStmtNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            var expression = FindChild("expression");
            if (expression != null)
            {
                str.Append("return ");
                str.Append(base.ToJs());
            }
            else
            {
                if (Context.ChildNodes.Count > 0)
                {
                    str.Append(Context.ChildNodes[0].Token.Text);
                }
            }

            return str.ToString();
        }
    }
}
