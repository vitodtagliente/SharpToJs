﻿using System.Text;

namespace GrammarLib.AST
{
    public class ConstructorNode : JsNode
    {
        public ParametersNode Parameters { get; private set; }

        public override void SetBehaviour()
        {
            Parameters = FindChild<ParametersNode>();
        }

        public override string ToJs()
        {
            return string.Empty;
        }
    }
}
