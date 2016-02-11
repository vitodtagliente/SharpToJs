using System.Collections.Generic;
using System.Text;
using Irony.Parsing;

namespace SharpToJs.AST
{
    public class ParametersNode : JsNode
    {
        List<string> Parameters = new List<string>();

        public override void SetBehaviour()
        {
            var param = FindChildren<IdentifierToken>();
            foreach (var p in param)
                Parameters.Add(p.Value);
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            string add = string.Empty;
            foreach(var p in Parameters)
            {
                str.Append(add);
                str.Append("var ");
                str.Append(p);
                add = ", ";
            }
            return str.ToString();
        }
    }
}
