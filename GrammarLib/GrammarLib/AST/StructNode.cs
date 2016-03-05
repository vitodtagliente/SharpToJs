using System.Text;

namespace SharpToJs.AST
{
    public class StructNode : JsNode
    {
        IdentifierToken id;
        JsNode elements;

        public override void AfterBehaviour()
        {
            id = FindChild<IdentifierToken>(false);
            elements = FindChild("struct-elements");
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(string.Empty);
            str.Append(AST.Table.CurrentNamespace.Name);
            str.Append(".");
            str.Append(id.Value);
            str.Append(" = function(){");
            str.AppendLine(string.Empty);

            Shift();

            if (elements != null)
            {
                str.Append(elements.ToJs());         
            }

            Unshift();
            
            str.Append("}");
            str.AppendLine(string.Empty);

            return str.ToString();
        }
    }
}
