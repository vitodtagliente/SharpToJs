
namespace SharpToJs.AST
{
    public class MainNode : JsNode
    {
        public static MainNode singleton { get; private set; }

        public override void AfterInit()
        {
            if (singleton == null)
            {
                singleton = this;
            }
            else
            {
                AST.Errors = ("Cannot exist 2 Main functions");
                AST.Errors = string.Format("Semantic Error on " + ToPosition());
            }
        }

        public string Compile()
        {
            return base.ToJs().Trim().Trim('{').Trim('}');
        }

        public override string ToJs()
        {
            return string.Empty;
        }
    }
}
