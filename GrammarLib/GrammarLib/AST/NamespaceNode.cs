using System.Collections.Generic;
using System.Text;

namespace SharpToJs.AST
{
    public class NamespaceNode : JsNode
    {
        static List<string> Namespaces = new List<string>();

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

            string current_namespace = string.Empty;
            var pieces = Name.Split('.');
            string comma = string.Empty;
            bool root_namespace = true;
            for (int i = 0; i < pieces.Length; i++)
            {
                current_namespace += (comma + pieces[i]);
                str.Append(build(current_namespace, root_namespace));
                comma = ".";
                root_namespace = false;
            }

            str.AppendLine(base.ToJs());

            AST.Table.Pop();

            return str.ToString();
        }

        string build(string namespace_name, bool root_namespace = false)
        {
            if (Namespaces.Contains(namespace_name))
                return string.Empty;
            Namespaces.Add(namespace_name);

            StringBuilder str = new StringBuilder();
            if (root_namespace)
                str.Append("var ");
            str.Append(namespace_name);
            str.Append(" = ");
            str.Append(namespace_name);
            str.Append(" || {};");
            str.AppendLine(string.Empty);
            
            return str.ToString();
        }
    }
}
