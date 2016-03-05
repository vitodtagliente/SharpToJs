using System.Text;

namespace SharpToJs.AST
{
    public class EnumNode : JsNode
    {
        IdentifierToken id;
        JsNode elements;

        public override void AfterBehaviour()
        {
            id = FindChild<IdentifierToken>(false);
            elements = FindChild("enum-elements");
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

            if(elements != null)
            {
                string comma = string.Empty;
                foreach(var element in elements.FindChildren<IdentifierToken>())
                {
                    str.Append(comma);
                    str.AppendLine(string.Empty);
                    str.Append(Tab);
                    str.Append("'");
                    str.Append(element.Value);
                    str.Append("': '");
                    str.Append(element.Value.ToLower());
                    str.Append("'");
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
