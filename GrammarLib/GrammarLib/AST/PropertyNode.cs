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

            var body = FindChild("property-body");
            if (body != null)
                str.AppendLine(body.ToJs());

            Unshift();

            str.Append(Tab);
            str.AppendLine("} );");
            return str.ToString();
        }
    }
}
