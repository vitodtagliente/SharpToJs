using System.Text;

namespace SharpToJs.AST
{
    public class ElementNode : JsNode
    {
        public override string ToJs()
        {
            if (IsLeaf)
                return "null";
            return base.ToJs();
        }
    }
}
