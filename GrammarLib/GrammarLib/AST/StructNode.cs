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
            str.Append(" = {");

            Shift();

            if (elements != null)
            {
                string comma = string.Empty;
                foreach(var element in elements.FindChildren<FieldNode>())
                {
                    str.Append(comma);
                    str.AppendLine(string.Empty);
                    str.Append(Tab);

                    var i = element.FindChild<IdentifierToken>(false);
                    str.Append(i.Value);
                    var e = element.FindChild<ElementNode>();
                    if (e != null)
                    {
                        str.Append(": ");
                        str.Append(e.ToJs());
                    }
                    else str.Append(": null");

                    comma = ", ";
                }                
            }

            Unshift();

            str.AppendLine(string.Empty);
            str.Append("};");
            str.AppendLine(string.Empty);

            return str.ToString();
        }
    }
}
