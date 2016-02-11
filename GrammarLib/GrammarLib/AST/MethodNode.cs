using System.Text;

namespace SharpToJs.AST
{
    public class MethodNode : JsNode
    {
        VisibilityModifierNode modifiers;
        IdentifierToken id;
        ParametersNode parameters;

        public override void SetBehaviour()
        {
            modifiers = FindChild<VisibilityModifierNode>();
            id = FindChild<IdentifierToken>();
            parameters = FindChild<ParametersNode>();
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(string.Empty);
            str.Append(modifiers.Value);
            str.Append(id.Value);
            str.Append(" = function(");
            if(parameters != null)
                str.Append(parameters.ToJs());
            str.Append(")");
            str.Append("{");
            str.AppendLine(string.Empty);

            str.AppendLine(string.Empty);
            str.AppendLine("}");

            return str.ToString();
        }
    }
}
