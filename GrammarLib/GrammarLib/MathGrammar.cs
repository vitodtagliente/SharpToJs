using Irony.Parsing;
using Irony.Interpreter;
using Irony.Interpreter.Ast;

namespace GrammarLib
{
    [Language("Math", "1.0", "Math grammar, Author: Vito Domenico Tagliente")]
    public class MathGrammar : Irony.Parsing.Grammar
    {
        public MathGrammar()
        {
            #region Terminals
                        
            Terminal numberToken = new NumberLiteral("number-token");
            numberToken.AstConfig.NodeType = typeof(LiteralValueNode);
            Terminal identifierToken = new IdentifierTerminal("identifier-token");
            identifierToken.AstConfig.NodeType = typeof(IdentifierNode);

            #endregion

            NonTerminal program = new NonTerminal("program", typeof(ExpressionListNode));
            NonTerminal expression = new NonTerminal("expression");
            NonTerminal element = new NonTerminal("element");
            NonTerminal binary_expression = new NonTerminal("binary-expression", typeof(BinExpression));
            NonTerminal binary_operator = new NonTerminal("binary-operator", "operator");
            
            this.Root = program;

            program.Rule = MakeStarRule(program, null, expression);

            expression.Rule = Empty 
                | element
                | binary_expression
                ;

            element.Rule = identifierToken
                | numberToken
                ;

            binary_expression.Rule = expression + binary_operator + expression;

            binary_operator.Rule = ToTerm("+") | "-" | "*" | "/";
                ;
            
            RegisterOperators(1, "+", "-");
            RegisterOperators(2, "*", "/");
            
            MarkTransient(element, binary_operator, expression);
            AddOperatorReportGroup("operator");
            
            this.LanguageFlags = LanguageFlags.NewLineBeforeEOF | LanguageFlags.CreateAst;
        }
    }
}
