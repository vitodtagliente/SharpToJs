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
            id = FindChild<IdentifierToken>();
        }

        public override void Check()
        {
            var symbol = new ST.Symbol(id.Value, "attribute");
            if (modifiers.IsPublic)
                symbol.SetPublic();
            symbol.Scope = AST.Table.CurrentClass.Name;

            var type = FindChild("qualified-type");
            symbol.Type = type.ToJs();

            AST.Table.Elements.Add(symbol);
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
                str.Append(FindChild("primary-expression").ToJs());
            }

            str.Append(";");
            str.AppendLine(string.Empty);

            return str.ToString();
        }
    }
}
