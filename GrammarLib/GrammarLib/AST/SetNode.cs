using System.Text;

namespace SharpToJs.AST
{
    public class SetNode : JsNode
    {
        public override void SetBehaviour()
        {
            var modifiers = FindChild<VisibilityModifierNode>();
            if (modifiers != null)
                modifiers.Remove();
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            if(Children.Count > 0)
            {
                str.Append(Tab);
                str.AppendLine("set: function( value )");
                str.Append(base.ToJs());
            }
            return str.ToString();
        }
    }
}
