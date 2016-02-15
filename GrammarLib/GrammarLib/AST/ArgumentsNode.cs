using System.Text;

namespace SharpToJs.AST
{
    public class ArgumentsNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            var arguments = FindChildren<ArgumentNode>(false);
            string comma = string.Empty;
            foreach (var argument in arguments)
            {
                str.Append(comma);
                str.Append(argument.ToJs());
                comma = ", ";
            }

            return str.ToString();
        }
    }
}
