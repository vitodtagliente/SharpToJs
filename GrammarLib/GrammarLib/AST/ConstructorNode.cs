using System.Text;

namespace SharpToJs.AST
{
    public class ConstructorNode : JsNode
    {
        public ParametersNode Parameters { get; private set; }

        public override void SetBehaviour()
        {
            Parameters = FindChild<ParametersNode>();
        }

        public override string ToJs()
        {
            var body = FindChild<BlockNode>();
            if(body==null)
            return string.Empty;

            var stmts = body.FindChild("statements");
            if (stmts != null)
                return stmts.ToJs();
            return string.Empty;
        }
    }
}
