using System.Text;

namespace SharpToJs.AST
{
    public class PropertyNode : JsNode
    {
        IdentifierToken id;
        GetNode get;
        SetNode set;

        public override void SetBehaviour()
        {
            id = FindChild<IdentifierToken>();
            get = FindChild<GetNode>();
            set = FindChild<SetNode>();
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Empty);
            str.Append("Object.defineProperty( this, '" + id.Value + "', {");

            if (get != null && get.IsLeaf == false)
            {
                str.AppendLine(string.Empty);
                str.Append(get.ToJs());
            }

            if (set != null && set.IsLeaf == false)
            {
                str.AppendLine(string.Empty);
                str.Append(set.ToJs());
            }

            str.AppendLine("} );");
            return str.ToString();
        }
    }
}
