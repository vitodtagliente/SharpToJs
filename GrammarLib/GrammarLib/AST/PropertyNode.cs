using System.Text;

namespace SharpToJs.AST
{
    public class PropertyNode : JsNode
    {
        public string Name { get; private set; }
        IdentifierToken id;
        VisibilityModifierNode modifiers;

        public override void SetBehaviour()
        {            
            id = FindChild<IdentifierToken>();
            Name = string.Empty;
            if (id != null)
            {
                Name = id.Value;
            }
        }

        public override void Check()
        {
            modifiers = FindChild<VisibilityModifierNode>();
            var symbol = new ST.Symbol(Name, "property");
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

            str.AppendLine(string.Empty);
            str.Append(Tab);
            str.Append("Object.defineProperty( this, '" + id.Value + "', {");
            str.AppendLine(string.Empty);

            Shift();

            //var body = FindChild("property-body");
            var get = FindChild<GetNode>(true);
            var set = FindChild<SetNode>(true);

            if (get != null)
            {
                str.Append(get.ToJs());
                if (set.IsLeaf == false)
                    str.Append(",");
            }
            if (set != null)
            {
                str.Append(set.ToJs());
            }

            Unshift();

            str.Append(Tab);
            str.AppendLine("} );");
            return str.ToString();
        }
    }
}
