using System.Text;

namespace SharpToJs.AST
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
            set
            {
                Status = AbstractSyntaxTreeStatus.Error;
                strErrors.AppendLine(value);
            }
        }

        public AbstractSyntaxTreeStatus Status { get; private set; }

        public ST.SymbolTable Table { get; private set; }

        public AbstractSyntaxTree(JsNode root)
        {
            Table = new ST.SymbolTable();

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
