using System;
using Irony;
using Irony.Parsing;
using Irony.Ast;
using Irony.Interpreter.Ast;

namespace GrammarLib
{
    public class JavascriptGenerator
    {
        public Grammar Grammar { get; private set; }
        public LanguageData Language { get; private set; }
        public Parser Parser { get; private set; }

        public JavascriptGenerator(Grammar grammar)
        {
            Grammar = grammar;
            Language = new LanguageData(Grammar);
            Parser = new Parser(Language);

            

        }
    }
}
