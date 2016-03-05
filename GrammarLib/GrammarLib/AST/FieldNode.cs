using System.Text;

namespace SharpToJs.AST
{
    public class FieldNode : JsNode
    {
        VisibilityModifierNode modifiers;
        IdentifierToken id;

        public override void BeforeBehaviour()
        {
            modifiers = FindChild<VisibilityModifierNode>();
            id = FindChild<IdentifierToken>();
        }

        public override void AfterBehaviour()
        {
            var symbol = new ST.Symbol(id.Value, "attribute");
            if (modifiers.IsPublic)
                symbol.SetPublic();
            if (AST.Table.CurrentClass != null)
                symbol.Scope = AST.Table.CurrentClass.Name;

            var type = FindChild("qualified-type");
            symbol.Type = type.ToJs();
            if (string.IsNullOrEmpty(symbol.Type))
                symbol.Type = "void";

            var p_expr = FindChild<PrimaryExpressionNode>(false);
            if(p_expr != null && symbol.Type != p_expr.Type && p_expr.Type != "null" && string.IsNullOrEmpty(p_expr.Type) == false)
            {
                AST.Errors = "Type Check Error";
                AST.Errors = "Semantic Error on " + ToPosition();
                AST.Errors = symbol.Name + " cannot be " + p_expr.Type;
            }

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
