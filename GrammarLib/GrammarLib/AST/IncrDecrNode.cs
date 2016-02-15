using System.Text;

namespace SharpToJs.AST
{
    public class IncrDecrNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            foreach (var child in Children)
            {
                if (child.GetType() == typeof(OperatorNode))
                {
                    str.Append(((OperatorNode)child).ToJs().Replace(" ", string.Empty));
                }
                else str.Append(((JsNode)child).ToJs());
            }
            return str.ToString();
        }
    }
}
