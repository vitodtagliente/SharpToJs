using System.Text;

namespace SharpToJs.AST
{
    public class NamespaceNode : JsNode
    {
        public string Name { get; private set; }

        public override void SetBehaviour()
        {            
            foreach(var child in Children)
            {
                if (child.GetType() == typeof(QualifiedIdentifierNode))
                {
                    Name = ((QualifiedIdentifierNode)child).Value;

                    AST.Table.Push(new Symbol(Name, "namespace"));

                    Children.Remove(child);
                    break;
                }
            }
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.Append("var ");
            str.Append(Name);
            str.Append(" = ");
            str.Append(Name);
            str.Append(" || {};");
            str.AppendLine(string.Empty);
            str.AppendLine(base.ToJs());

            AST.Table.Pop();

            return str.ToString();
        }
    }
}
