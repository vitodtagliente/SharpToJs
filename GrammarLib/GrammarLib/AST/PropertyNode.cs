using System.Text;

namespace SharpToJs.AST
{
    public class PropertyNode : JsNode
    {
        public string Name { get; private set; }
        IdentifierToken id;

        public override void SetBehaviour()
        {
            id = FindChild<IdentifierToken>();
            Name = string.Empty;
            if (id != null)
            {
                Name = id.Value;
            }
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
