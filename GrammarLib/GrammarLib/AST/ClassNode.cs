using System.Collections.Generic;
using System.Text;

namespace SharpToJs.AST
{
    public class ClassNode : JsNode
    {
        public ConstructorNode Constructor { get; private set; }
        public string Name { get; private set; }

        public override void AfterInit()
        {
            Check();
        }

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

        public override void Check()
        {
            AST.Table.PushClass(Name, string.Empty);
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            
            str.AppendLine(string.Empty);
            str.Append(AST.Table.CurrentNamespace.Name);
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
            str.Append(Tab);
            str.AppendLine("// Constructor");
            str.AppendLine(string.Empty);
            str.AppendLine(Constructor.ToJs());
            str.AppendLine(string.Empty);

            Unshift();

            str.AppendLine("}");
            str.AppendLine(string.Empty);

            // inserisco lestensione

            var class_params = FindChild("class-params");
            if(class_params.IsLeaf == false)
            {
                var param = class_params.FindChild("class-param");

                str.Append(AST.Table.CurrentClass.Name);
                str.Append(".");
                str.Append(Name);
                str.Append(".prototype = new ");
                str.Append(param.ToJs());
                str.Append("();");
                str.AppendLine(string.Empty);
            }

            AST.Table.PopClass();
            
            return str.ToString();
        }
    }
}
