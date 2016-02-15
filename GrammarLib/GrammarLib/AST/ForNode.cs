using System.Text;

namespace SharpToJs.AST
{
    public class ForNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.Append("for(");

            var for_initializer = FindChild("for-initializer");
            if (for_initializer != null)
                str.Append(for_initializer.ToJs());

            str.Append(";");

            var for_condition = FindChild("for-condition");
            if (for_condition != null)
                str.Append(for_condition.ToJs());

            str.Append(";");

            var for_iterator = FindChild("for-iterator");
            if (for_iterator != null)
                str.Append(for_iterator.ToJs());

            str.Append(")");

            Shift();

            str.AppendLine(string.Empty);
            str.Append(Tab);
            str.Append(FindChild("embedded-statement").ToJs());
            str.Append(";");

            Unshift();

            return str.ToString();
        }
    }
}
