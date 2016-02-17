
namespace SharpToJs.AST
{
    public class QualifiedIdentifierNode : JsNode
    {
        public string Value { get; private set; }

        public override void SetBehaviour()
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
            if (Value.StartsWith("this."))
                return Value;
            string before = string.Empty;
            foreach(var member in AST.Table.PublicMembers)
            {
                var pieces = Value.Split('.');

                if (member.Equals(pieces[0]))
                    before = "this.";
            }
            return (before + Value);
        }
    }
}
