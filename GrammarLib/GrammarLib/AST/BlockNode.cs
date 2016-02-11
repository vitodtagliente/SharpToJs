﻿using System.Text;

namespace SharpToJs.AST
{
    public class BlockNode : JsNode
    {
        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("{");
            str.AppendLine(base.ToJs());
            str.AppendLine("}");
            str.AppendLine(string.Empty);
            return str.ToString();
        }
    }
}
