
namespace SharpToJs.AST
{
    public class QualifiedIdentifierNode : JsNode
    {
        public string Value { get; private set; }

        public override void BeforeBehaviour()
        {
            string comma = string.Empty;
            for (int i = 0; i < Context.ChildNodes.Count; i++)
            {
                Value += (comma + Context.ChildNodes[i].Token.Value);
                comma = ".";
            }
        }

        public override string ToJs()
        {
            if (Value.StartsWith("this.") || AST.Table.CurrentClass == null)
                return Value;
            string before = string.Empty;

            var pieces = Value.Split('.');
            foreach (var member in AST.Table.FindClassElements(AST.Table.CurrentClass.Name))
            {
                if (member.Name.Equals(pieces[0]) && member.IsPublic)
                {
                    before = "this.";
                    break;
                }
            }
            return (before + Value);
        }
    }
}
