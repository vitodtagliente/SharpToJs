using System.Text;

namespace SharpToJs.AST
{
    public class TypeOfNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            str.Append("typeof ");

            var stmt = FindChild("primary-expression");
            str.Append(stmt.ToJs());

            return str.ToString();
        }
    }
}
