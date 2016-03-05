using System.Text;

namespace SharpToJs.AST
{
    public class GetNode : JsNode
    {
        public override void BeforeBehaviour()
        {
            var modifiers = FindChild<VisibilityModifierNode>();
            if (modifiers != null)
                modifiers.Remove();
        }

        public override void AfterBehaviour()
        {
            if(FindChild<ReturnStmtNode>() == null)
            {
                AST.Errors = "Cannot find return statement on " + ToPosition();
            }
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            if(Children.Count > 0)
            {
                str.Append(Tab);
                str.AppendLine("get: function()");
                str.Append(base.ToJs());
            }
            return str.ToString();
        }
    }
}
