using System.Text;

namespace GrammarLib.AST
{
    public class BlockNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("{");
            str.AppendLine(base.ToJs());
            str.AppendLine("}");
            return str.ToString();
        }
    }
}
