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

            Check();
        }

        public override void Check()
        {
            var symbol = new ST.Symbol(id.ToJs(), "method");
            if (modifiers.IsPublic)
                symbol.SetPublic();
            symbol.Parent = AST.Table.CurrentClass.Name;
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
