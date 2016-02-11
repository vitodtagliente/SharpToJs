using System.Text;

namespace SharpToJs.AST
{
    public class SetNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("\tset: function( value )");
            str.Append(base.ToJs());
            return str.ToString();
        }
    }
}
