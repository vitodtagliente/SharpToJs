
namespace SharpToJs.AST
{
    public class PrimaryExpressionNode : JsNode
    {
        public string Type { get; private set; }

        public override void BeforeBehaviour()
        {
            Type = string.Empty;

            JsNode child = FindChild<ElementNode>(false);
            if(child != null)
            {
                Type = ((ElementNode)child).Type;
                return;
            }
            child = FindChild<TypeOfNode>(false);
            if(child != null)
            {
                var p_exp = child.FindChild<PrimaryExpressionNode>();
                Type = p_exp.Type;
                return;
            }
            child = FindChild<ObjectCreationNode>(false);
            if(child != null)
            {
                var obj = child.FindChild<QualifiedIdentifierNode>();
                Type = obj.Value;
                return;
            }
        }
    }
}
