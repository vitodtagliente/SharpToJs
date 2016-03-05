
namespace SharpToJs.AST
{
    public class ElementNode : JsNode
    {
        public string Type { get; private set; }

        public override void BeforeBehaviour()
        {
            Type = string.Empty;
            if(IsLeaf)
            {
                Type = "null";
                return;
            }
            JsNode child = FindChild("builtin-element");
            if(child != null)
            {
                if (child.FindChild<StringNode>() != null)
                    Type = "string";
                else if (child.FindChild<NumberNode>() != null)
                    Type = "int";
                else Type = "bool";
                return;
            }
            child = FindChild<ObjectNode>();
            if(child != null)
            {

                return;
            }
            child = FindChild<MemberExpressionNode>();
            if(child != null)
            {

                return;
            }
        }

        public override string ToJs()
        {
            if (IsLeaf)
                return "null";
            return base.ToJs();
        }
    }
}
