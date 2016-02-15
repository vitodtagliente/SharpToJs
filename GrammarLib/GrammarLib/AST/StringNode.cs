﻿
namespace SharpToJs.AST
{
    public class StringNode : JsNode
    {
        public string Value { get; private set; }

        public override void SetBehaviour()
        {
            Value = Context.Token.Text;
        }

        public override string ToJs()
        {
            return Value;
        }
    }
}
