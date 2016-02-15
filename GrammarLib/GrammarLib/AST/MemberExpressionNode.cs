using System.Text;

namespace SharpToJs.AST
{
    public class MemberExpressionNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            var children = FindChildren<ObjectNode>(false);
            string comma = string.Empty;
            foreach (var child in children)
            {
                str.Append(comma);
                str.Append(child.ToJs());
                comma = ".";
            }

            return str.ToString();
        }
    }
}
