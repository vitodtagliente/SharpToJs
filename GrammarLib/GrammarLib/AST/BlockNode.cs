﻿using System.Text;

namespace SharpToJs.AST
{
    public class BlockNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Tab);
            str.AppendLine("{");

            Shift();

            str.Append(base.ToJs());

            Unshift();

            str.Append(Tab);
            str.AppendLine("}");
            return str.ToString();
        }
    }
}
