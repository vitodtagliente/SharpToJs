using System.Text;

namespace SharpToJs.AST
{
    public class ProgramNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Empty);
            str.AppendLine("/*");
            str.AppendLine(" * Build with SharpToJs Compiler");
            str.AppendLine(" * Author: Vito Domenico Tagliente");
            str.AppendLine(" */");
            str.AppendLine(string.Empty);
            str.AppendLine(base.ToJs());
            return str.ToString();
        }
    }
}
