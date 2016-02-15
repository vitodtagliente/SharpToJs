using System.Text;

namespace SharpToJs.AST
{
    public class ClassNode : JsNode
    {
        public ConstructorNode Constructor { get; private set; }
        public string Name { get; private set; }
        
        public override void SetBehaviour()
        {
            Constructor = FindChild<ConstructorNode>();
            if(Constructor != null)
            {
                Constructor.Parent.Children.Remove(Constructor);
            }
            var identifier = FindChild<IdentifierToken>();
            if(identifier != null)
                Name = identifier.Value;
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            
            str.AppendLine(string.Empty);
            str.Append(AST.Table.Last.Name);
            str.Append(".");
            str.Append(Name);
            str.Append(" = function(");

            str.Append(Constructor.Parameters.ToJs());

            str.Append(")");
            str.AppendLine("{");
            str.AppendLine(string.Empty);

            Shift();

            var body = FindChild<ClassBodyNode>();
            if (body != null)
                str.Append(body.ToJs());

            // inserisco le operazioni del costruttore
            str.AppendLine(string.Empty);
            str.AppendLine("// Constructor");
            str.AppendLine(string.Empty);
            str.AppendLine(Constructor.ToJs());
            str.AppendLine(string.Empty);

            Unshift();

            str.AppendLine("}");
            str.AppendLine(string.Empty);

            // inserisco lestensione

            return str.ToString();
        }
    }
}
