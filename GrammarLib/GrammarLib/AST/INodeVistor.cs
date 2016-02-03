using Irony.Ast;

namespace GrammarLib.AST
{
    public interface INodeVistor
    {
        void Visit(Nodes.IdentifierNode node);
    }
}
