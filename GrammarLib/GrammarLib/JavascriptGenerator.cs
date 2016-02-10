using Irony.Parsing;
using System.Text;

namespace GrammarLib
{
    public class JavascriptGenerator
    {
        public Grammar Grammar { get; private set; }
        public LanguageData Language { get; private set; }
        public Parser Parser { get; private set; }

        StringBuilder strErrors = new StringBuilder();
        public string Errors
        {
            get { return strErrors.ToString(); }
            private set { strErrors.AppendLine(value); }
        }

        public AST.JsNode AbstractSyntaxTree { get; private set; }

        public JavascriptGenerator(Grammar grammar)
        {
            Grammar = grammar;
            Language = new LanguageData(Grammar);
            Parser = new Parser(Language);
        }

        public bool Parse(string source)
        {
            var parse_tree = Parser.Parse(source);
            if(parse_tree.Status == ParseTreeStatus.Error)
            {
                foreach (var message in parse_tree.ParserMessages)
                    Errors = message.ToString();
                return false;
            }

            // create AST
            
            AbstractSyntaxTree = (AST.JsNode)AST.NodeFactory.Map(parse_tree.Root);
            if (AbstractSyntaxTree == null)
            {
                Errors = "Cannot parse AST";
                return false;
            }

            return true;
        }

        public string Compile()
        {
            if (AbstractSyntaxTree != null)
                return AbstractSyntaxTree.ToJS();
            return string.Empty;
        }
    }
}
