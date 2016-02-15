using System.Text;

namespace SharpToJs.AST
{
    public class FunctionArgumentsNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            if (Children.Count > 0)
            {
                str.Append("( ");

                str.Append(base.ToJs());

                str.Append(" )");
            }
            return str.ToString();
        }
    }
}
