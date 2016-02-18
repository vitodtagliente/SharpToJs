using System;

namespace SharpToJs.AST
{
    public class MainNode : JsNode
    {
        public static MainNode singleton { get; private set; }

        public override void AfterInit()
        {
            if(singleton == null)
            {
                singleton = this;
            }
            else
            {
                AST.Errors = ("Cannot exist 2 main functions");
                new Exception();
            }
        }

        public string ToScript()
        {
            return base.ToJs();
        }

        public override string ToJs()
        {
            return string.Empty;
        }
    }
}
