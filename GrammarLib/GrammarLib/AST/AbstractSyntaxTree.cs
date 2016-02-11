using System.Text;

namespace GrammarLib.AST
{
    public enum AbstractSyntaxTreeStatus
    {
        Error = 0,
        Parsing,
        Parsed
    }

    public class AbstractSyntaxTree
    {
        public JsNode Root { get; private set; }

        StringBuilder strErrors = new StringBuilder();
        public string Errors
        {
            get { return strErrors.ToString(); }
            private set
            {
                Status = AbstractSyntaxTreeStatus.Error;
                strErrors.AppendLine(value);
            }
        }

        public AbstractSyntaxTreeStatus Status { get; private set; }

        public SymbolTable Table { get; private set; }

        public AbstractSyntaxTree(JsNode root)
        {
            Table = new SymbolTable();

            Status = AbstractSyntaxTreeStatus.Error;

            Root = root;            
        }

        public void Parse()
        {
            Status = AbstractSyntaxTreeStatus.Parsing;
            if (Root == null)
            {
                Errors = "The root node cannot be NULL";
                return;
            }
            
            Status = AbstractSyntaxTreeStatus.Parsed;
            Root.AST = this;
            Root.Parse();
        }

        public string ToJs()
        {
            if (Status == AbstractSyntaxTreeStatus.Error)
                return string.Empty;
            return Root.ToJs();
        }
    }
}
