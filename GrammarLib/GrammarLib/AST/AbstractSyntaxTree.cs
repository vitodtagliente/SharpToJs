using System.Text;

namespace SharpToJs.AST
{
    public enum AbstractSyntaxTreeStatus
    {
        Error = 0,
        Parsing,
        SemanticCheck,
        Parsed
    }

    public class AbstractSyntaxTree
    {
        public JsNode Root { get; private set; }

        StringBuilder strErrors = new StringBuilder();
        public string Errors
        {
            get { return strErrors.ToString(); }
            set
            {
                Status = AbstractSyntaxTreeStatus.Error;
                strErrors.AppendLine(value);
            }
        }

        public AbstractSyntaxTreeStatus Status { get; private set; }

        static ST.SymbolTable _table = new ST.SymbolTable();
        public ST.SymbolTable Table { get { return _table; } }

        public AbstractSyntaxTree(JsNode root)
        {
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

        public void Check()
        {
            Status = AbstractSyntaxTreeStatus.SemanticCheck;
            Root.SemanticCheck();
        }

        public string ToJs()
        {
            if (Status == AbstractSyntaxTreeStatus.Error)
                return string.Empty;
            return Root.ToJs();
        }
    }
}
