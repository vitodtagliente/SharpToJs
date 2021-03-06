﻿
namespace SharpToJs.AST
{
    public class VisibilityModifierNode : JsNode
    {
        public string Value { get; private set; }
        bool is_public = false;
        public bool IsPublic {
            get { return is_public; }
        }

        public override void BeforeBehaviour()
        {
            Value = string.Empty;
            var value = string.Empty;

            var modifiers = FindChildren<KeywordNode>();
            string comma = string.Empty;
            foreach (var m in modifiers)
            {
                value += (comma + m.Value);
                comma = " ";
            }

            if (value.Contains("public") && value.Contains("private"))
            {
                AST.Errors = ("Semanthic Error: cant use both public and private modifiers");
            }

            if (string.IsNullOrEmpty(value) || value.Contains("private"))
            {
                Value = "var ";
            }
            else if (value.Contains("public"))
            {
                Value = "this.";
                is_public = true;
            }
        }

        public override string ToJs()
        {            
            return Value;
        }
    }
}
