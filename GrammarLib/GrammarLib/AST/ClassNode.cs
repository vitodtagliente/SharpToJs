using System.Text;
using Irony.Parsing;

namespace GrammarLib.AST
{
    public class ClassNode : JsNode
    {
        public ConstructorNode Constructor { get; private set; }
        public string Name { get; private set; }

        public override void AfterInit()
        {
            Constructor = FindInChildren<ConstructorNode>();
            var identifier = FindInChildren<IdentifierToken>();
            if(identifier != null)
            {
                Name = identifier.Value;
                Children.Remove(identifier);
            }            
        }

        public override string ToJS()
        {
            StringBuilder str = new StringBuilder();
            
            str.AppendLine(string.Empty);
            str.Append(Table.Last.Name);
            str.Append(".");
            str.Append(Name);
            str.Append(" = function()");
            str.AppendLine("{");
            str.AppendLine(string.Empty);

            str.Append(base.ToJS());

            str.AppendLine(string.Empty);
            str.AppendLine("}");
            str.AppendLine(string.Empty);

            return str.ToString();
        }
    }
}
