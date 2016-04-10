using System.Text;

namespace SharpToJs.AST
{
    public class AssignmentStmtNode : JsNode
    {
        public override void AfterBehaviour()
        {
            var obj_token = FindChild("object-token");
            var id = obj_token.FindChild<QualifiedIdentifierNode>();
            if(id != null)
            {
                var symbol = AST.Table.Find(id.Value);
                if (symbol == null)
                    return;
            }
        }

        public override string ToJs()
        {
            return base.ToJs();
        }
    }
}
