﻿using System.Collections.Generic;
using System.Text;

namespace SharpToJs.AST
{
    public class FieldNode : JsNode
    {
        VisibilityModifierNode modifiers;
        IdentifierToken id;

        public override void SetBehaviour()
        {
            modifiers = FindChild<VisibilityModifierNode>();
            id = FindChild<IdentifierToken>();
        }

        public override string ToJs()
        {
            StringBuilder str = new StringBuilder();

            str.Append(modifiers.Value);
            str.Append(id.Value);
            if (FindSymbolInChild("="))
            {
                str.Append(" = ");

            }

            str.Append(";");
            str.AppendLine(string.Empty);

            return str.ToString();
        }
    }
}