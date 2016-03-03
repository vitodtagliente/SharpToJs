using System.Collections.Generic;
using System.Text;

namespace SharpToJs.AST
{
    public class NamespaceNode : JsNode
    {
        static List<string> Namespaces = new List<string>();

        public string Name { get; private set; }

        public override void Check()
        {
            AST.Table.PushNamespace(Name);
        }

        public override void SetBehaviour()
        {
            var id = FindChild<QualifiedIdentifierNode>();
            Name = id.Value;

            Children.Remove(id);
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

            AST.Table.PopNamespace();

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
