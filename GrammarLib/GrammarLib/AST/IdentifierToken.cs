﻿
namespace SharpToJs.AST
{
    public class IdentifierToken : JsNode
    {
        public string Value { get; private set; }

        public override void BeforeBehaviour()
        {
            Value = Context.Token.Text;
        }

        public override string ToJs()
        {
            return Value;
        }
    }
}
