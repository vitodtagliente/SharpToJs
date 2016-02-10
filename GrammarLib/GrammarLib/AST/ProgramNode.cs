using System.Text;
using Irony.Parsing;

namespace GrammarLib.AST
{
    public class ProgramNode : JsNode
    {
        public override string ToJS()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(string.Empty);
            str.AppendLine("/*");
            str.AppendLine(" * Build with SharpToJs Compiler");
            str.AppendLine(" */");
            str.AppendLine(string.Empty);
            str.AppendLine(base.ToJS());
            return str.ToString();
        }
    }
}
