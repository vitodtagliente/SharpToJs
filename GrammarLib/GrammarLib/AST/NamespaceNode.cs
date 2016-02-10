﻿using System.Text;
using Irony.Parsing;

namespace GrammarLib.AST
{
    public class NamespaceNode : JsNode
    {
        public string Identifier { get; private set; }

        public override void AfterInit()
        {            
            foreach(var child in Children)
            {
                if (child.GetType() == typeof(QualifiedIdentifierNode))
                {
                    Identifier = ((QualifiedIdentifierNode)child).Value;

                    Table.Push(new Symbol(Identifier, "namespace"));

                    Children.Remove(child);
                    break;
                }
            }
        }

        public override string ToJS()
        {
            StringBuilder str = new StringBuilder();
            str.Append("var ");
            str.Append(Identifier);
            str.Append(" = ");
            str.Append(Identifier);
            str.Append(" || {};");
            str.AppendLine(string.Empty);
            str.AppendLine(base.ToJS());

            Table.Pop();

            return str.ToString();
        }
    }
}
