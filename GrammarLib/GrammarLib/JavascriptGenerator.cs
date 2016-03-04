using Irony.Parsing;
using System.Text;
using SharpToJs.AST;

namespace SharpToJs
{
    public class JavascriptGenerator
    {
        public Grammar Grammar { get; private set; } // Grammatica del linguaggio
        public LanguageData Language { get; private set; } 
        public Parser Parser { get; private set; } 

        // Gestione degli Errori
        StringBuilder strErrors = new StringBuilder();
        public string Errors
        {
            get { return strErrors.ToString(); }
            private set { strErrors.AppendLine(value); }
        }

        public AbstractSyntaxTree AbstractSyntaxTree { get; private set; }

        public JavascriptGenerator(Grammar grammar)
        {
            Grammar = grammar;
            Language = new LanguageData(Grammar);
            Parser = new Parser(Language);
        }

        public bool Parse(string source)
        {
            // Genera il ParseTree del file di input
            var parse_tree = Parser.Parse(source);
            if(parse_tree.Status == ParseTreeStatus.Error)
            {
                foreach (var message in parse_tree.ParserMessages)
                    Errors = message.ToString();
                return false;
            }

            // Mappa l'AST
            AbstractSyntaxTree = new AbstractSyntaxTree((JsNode)NodeFactory.Map(parse_tree.Root));
            AbstractSyntaxTree.Parse();
            if (AbstractSyntaxTree.Status == AbstractSyntaxTreeStatus.Error)
            {
                Errors = "Cannot parse AST";                    
                return false;
            }

            // Esegui il Controllo Semantico
            AbstractSyntaxTree.Check();
            if (AbstractSyntaxTree.Status == AbstractSyntaxTreeStatus.Error)
            {
                Errors = "Semantic Error";
                return false;
            }

            return true;
        }

        // Traduci L'AST generato nel corrispondente codice Javascript
        public string Compile()
        {
            if (AbstractSyntaxTree.Status != AbstractSyntaxTreeStatus.Error)
                return AbstractSyntaxTree.ToJs();
            return string.Empty;
        }
    }
}
