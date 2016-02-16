using System.Text;

namespace SharpToJs.AST
{
    public class TypecastNode : JsNode
    {
        public override string ToJs()
        {
            var stmt = FindChild("primary-expression");
            return stmt.ToJs();
        }
    }
}
