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

        public override void Check()
        {
            var symbol = new ST.Symbol(id.ToJs(), "method");
            if (modifiers.IsPublic)
                symbol.SetPublic();
            symbol.Scope = AST.Table.CurrentClass.Name;

            var type = FindChild("qualified-type");
            symbol.Type = type.ToJs();

            // Add parameters to symbol table
            if(parameters != null)
            {
                foreach(JsNode parameter in parameters.Children)
                {
                    var qi = parameter.FindChild("qualified-type");
                    var _id = parameter.FindChild<IdentifierToken>(false);

                    var p = new ST.Symbol(_id.Value, "parameter");
                    p.Scope = id.Value;
                    p.Type = qi.ToJs();

                    AST.Table.Elements.Add(p);
                }
            }

            AST.Table.Elements.Add(symbol);
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(string.Empty);
            str.Append(Tab);
            str.Append(modifiers.Value);
            str.Append(id.Value);
            str.Append(" = function(");
            if(parameters != null)
                str.Append(parameters.ToJs());
            str.Append(")");
            str.AppendLine(string.Empty);

            var body = FindChild<BlockNode>();
            if (body != null)
                str.Append(body.ToJs());

            return str.ToString();
        }
    }
}
