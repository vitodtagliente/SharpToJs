using System.Text;

namespace SharpToJs.AST
{
    public class FieldNode : JsNode
    {
        VisibilityModifierNode modifiers;
        IdentifierToken id;

        public override void SetBehaviour()
        {
            modifiers = FindChild<VisibilityModifierNode>();
            if (modifiers != null)
                modifiers.Remove();
            id = FindChild<IdentifierToken>();
            if (id != null)
                id.Remove();
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            str.Append(Tab);
            str.Append(modifiers.ToJs());
            str.Append(id.ToJs());
            if (FindSymbolInChildren("="))
            {
                str.Append(" = ");
                str.Append(base.ToJs());
            }

            str.Append(";");
            str.AppendLine(string.Empty);

            return str.ToString();
        }
    }
}
