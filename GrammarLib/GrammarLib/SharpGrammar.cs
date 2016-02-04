using System;
using Irony.Parsing;

namespace GrammarLib
{
    [Language("C#", "1.0", "My C# implementation, Author: Vito Domenico Tagliente")]
    public class SharpGrammar : Irony.Parsing.Grammar
    {
        public SharpGrammar()
        {

            #region Terminals

            CommentTerminal blockComment = new CommentTerminal("block-comment", "/*", "*/");
            CommentTerminal lineComment = new CommentTerminal("line-comment", "//",
                "\r", "\n", "\u2085", "\u2028", "\u2029");
            NonGrammarTerminals.Add(blockComment);
            NonGrammarTerminals.Add(lineComment);

            Terminal numberToken = new NumberLiteral("number-token");
            Terminal stringToken = new StringLiteral("string-token", "\"", StringOptions.None);
            Terminal identifierToken = new IdentifierTerminal("identifier-token");
                                    
            #endregion

            #region NonTerminals

            NonTerminal program = new NonTerminal("program");


            NonTerminal using_directives_lines = new NonTerminal("using-directives-lines");
            NonTerminal using_directives = new NonTerminal("using-directives");
            NonTerminal using_directive = new NonTerminal("using-directive");
            
            NonTerminal namespace_declarations = new NonTerminal("namespace-declarations");
            NonTerminal namespace_declaration = new NonTerminal("namespace-declaration");
            NonTerminal namespace_body = new NonTerminal("namespace-body");

            NonTerminal namespace_member_declarations = new NonTerminal("namespace-member-declarations");
            NonTerminal namespace_member_declaration = new NonTerminal("namespace-member-declaration");

            NonTerminal qualified_identifier = new NonTerminal("qualified-identifier");

            NonTerminal semi_colon = new NonTerminal("semi-colon");

            NonTerminal type_declaration = new NonTerminal("type-declaration");

            NonTerminal class_declaration = new NonTerminal("class-declaration");
            NonTerminal struct_declaration = new NonTerminal("struct-declaration");
            NonTerminal interface_declaration = new NonTerminal("interface-declaration");
            NonTerminal enum_declaration = new NonTerminal("enum-declaration");

            NonTerminal class_body = new NonTerminal("class-body");

            NonTerminal visibility_modifiers = new NonTerminal("visibility-modifiers");
            NonTerminal visibility_modifier = new NonTerminal("visibility-modifier");

            NonTerminal class_params = new NonTerminal("class-params");
            NonTerminal class_param = new NonTerminal("class-param");

            NonTerminal enum_elements = new NonTerminal("enum-elements");
            NonTerminal enum_element = new NonTerminal("enum-element");

            NonTerminal struct_elements = new NonTerminal("struct-elements");

            NonTerminal member_declarations = new NonTerminal("member-declarations");
            NonTerminal member_declaration = new NonTerminal("member-declaration");

            NonTerminal constant_declaration = new NonTerminal("constant-declaration");
            NonTerminal constant_declarators = new NonTerminal("constant-declarators");
            NonTerminal constant_declarator = new NonTerminal("constant-declarator");

            NonTerminal field_declaration = new NonTerminal("field-declaration");
            NonTerminal method_declaration = new NonTerminal("method-declaration");
            NonTerminal property_declaration = new NonTerminal("property-declaration");

            NonTerminal method_parameters = new NonTerminal("method-parameters");
            NonTerminal parameters = new NonTerminal("parameters");
            NonTerminal parameter = new NonTerminal("parameter");

            NonTerminal method_body = new NonTerminal("method-body");
            NonTerminal block = new NonTerminal("block");

            NonTerminal property_body = new NonTerminal("property-body");

            NonTerminal builtin_type = new NonTerminal("builtin-type");
            NonTerminal builtin_type_or_void = new NonTerminal("builtin-type-or-void");
            NonTerminal qualified_type = new NonTerminal("qualified-type");

            NonTerminal statements = new NonTerminal("statements");
            NonTerminal statement = new NonTerminal("statement");

            NonTerminal embedded_statement = new NonTerminal("embedded-statement");
            NonTerminal declaration_statement = new NonTerminal("declaration-statement");
            NonTerminal if_statement = new NonTerminal("if-statement");
            NonTerminal else_statement = new NonTerminal("else-statement");
            NonTerminal do_statement = new NonTerminal("do-statement");
            NonTerminal switch_statement = new NonTerminal("switch-statement");
            NonTerminal switch_body = new NonTerminal("switch-body");
            NonTerminal switch_sections = new NonTerminal("switch-section");
            NonTerminal switch_section = new NonTerminal("switch-section");
            NonTerminal foreach_statement = new NonTerminal("foreach-statement");
            NonTerminal for_statement = new NonTerminal("for-statement");
            NonTerminal for_initializer = new NonTerminal("for-initializer");
            NonTerminal for_condition = new NonTerminal("for-condition");
            NonTerminal for_iterator = new NonTerminal("for-iterator");
            NonTerminal while_statement = new NonTerminal("while-statement");
            NonTerminal expression_statement = new NonTerminal("expression-statement");

            NonTerminal variable_declarations = new NonTerminal("variable-declarations");
            NonTerminal variable_declaration = new NonTerminal("variable-declaration");

            NonTerminal assign_statement = new NonTerminal("assign-statement");

            NonTerminal relational_expression = new NonTerminal("relational-expression");
            NonTerminal math_expression = new NonTerminal("math-expression");

            NonTerminal expressions = new NonTerminal("expressions");
            NonTerminal expression = new NonTerminal("expression");

            NonTerminal object_creation_expression = new NonTerminal("object-creation-expression");

            NonTerminal unary_operator = new NonTerminal("unary-operator");
            NonTerminal assignment_operator = new NonTerminal("assignment-operator");
            NonTerminal binary_operator = new NonTerminal("binary-operator");
            NonTerminal inc_or_dec_operator = new NonTerminal("inc-or-dec-operator");

            NonTerminal boolean_token = new NonTerminal("boolean-token");
            NonTerminal object_token = new NonTerminal("object-token");

            NonTerminal element = new NonTerminal("element");

            NonTerminal function_arguments = new NonTerminal("function-arguments");
            NonTerminal arguments = new NonTerminal("arguments");
            NonTerminal argument = new NonTerminal("argument");

            #endregion

            #region Keywords

            this.MarkReservedWords(
                "return",
                "int", "string", "float", "void", "double", "long",
                "if", "do", "while", "for", "switch", "case", "break", 
                "using", "this"
                );

            #endregion

            this.Root = program;

            program.Rule = using_directives_lines + namespace_declarations;

            qualified_identifier.Rule = MakePlusRule(qualified_identifier, ToTerm("."), identifierToken);

            // Direttive di using

            using_directives_lines.Rule = Empty | using_directives;

            using_directives.Rule = MakePlusRule(using_directives, null, using_directive);

            using_directive.Rule = ToTerm("using") + qualified_identifier + ";"
                ;
            
            // Namespace

            namespace_declarations.Rule = MakeStarRule(namespace_declarations, null, namespace_declaration);

            namespace_declaration.Rule = ToTerm("namespace") + qualified_identifier + namespace_body + semi_colon;

            semi_colon.Rule = ToTerm(";")
                | Empty
                ;

            namespace_body.Rule = ToTerm("{") + namespace_member_declarations + "}"
                ;

            namespace_member_declarations.Rule = MakeStarRule(namespace_member_declarations, null, namespace_member_declaration);

            namespace_member_declaration.Rule = namespace_declaration
                | type_declaration
                ;

            type_declaration.Rule = class_declaration 
                | struct_declaration 
                | enum_declaration
                ;

            // Dichiarazione classi

            class_declaration.Rule = visibility_modifiers + "class" + identifierToken + class_params + class_body
                ;

            visibility_modifiers.Rule = MakeStarRule(visibility_modifiers, null, visibility_modifier);

            visibility_modifier.Rule = ToTerm("static")
                | "public"
                | "private"
                | "protected"
                ;

            class_params.Rule = ToTerm(":") + class_param
                | Empty
                ;

            class_param.Rule = MakePlusRule(class_param, ToTerm(","), qualified_identifier);

            class_body.Rule = ToTerm("{") + member_declarations + "}"
                ;

            member_declarations.Rule = MakeStarRule(member_declarations, null, member_declaration);

            member_declaration.Rule = constant_declaration
                | field_declaration
                | method_declaration
                | property_declaration
                ;

            member_declaration.ErrorRule = SyntaxError + ";"
                | SyntaxError + "}"
                ;

            // Dichiarazione struct

            struct_declaration.Rule = visibility_modifiers + "struct" + identifierToken + "{" + struct_elements + "}" + semi_colon;

            struct_elements.Rule = MakeStarRule(struct_elements, null, field_declaration);

            // Dichiarazione enumeratori

            enum_declaration.Rule = visibility_modifiers + "enum" + identifierToken + "{" + enum_elements + "}" + semi_colon;

            enum_elements.Rule = MakePlusRule(enum_elements, ToTerm(","), enum_element);

            enum_element.Rule = identifierToken;

            // Dichiarazione tipi

            builtin_type.Rule = ToTerm("int")
                | "bool" | "decimal" | "float" | "double" | "string" | "object"
                | "byte" | "short" | "ushort" | "uint" | "long" | "ulong" | "char" | "sbyte"
                ;

            builtin_type_or_void.Rule = builtin_type
                | "void"
                ;

            qualified_type.Rule = builtin_type_or_void
                | qualified_identifier
                | "var"
                ;

            // Dichiarazione costanti

            constant_declaration.Rule = visibility_modifiers + "const" + builtin_type + constant_declarators + ";"
                ;

            constant_declarators.Rule = MakePlusRule(constant_declarators, ToTerm(","), constant_declarator);

            constant_declarator.Rule = identifierToken
                | identifierToken + "=" + expressions
                ;

            // Dichiarazione Attribbuti

            field_declaration.Rule = visibility_modifiers + qualified_type + identifierToken + ";"
                | visibility_modifiers + qualified_type + identifierToken + "=" + expressions + ";"
                ;

            // Dichiarazione Metodi
            
            method_declaration.Rule = visibility_modifiers + qualified_type + identifierToken + method_parameters + method_body;

            method_parameters.Rule = ToTerm("(") + ")"
                | "(" + parameters + ")"
                ;

            parameters.Rule = MakePlusRule(parameters, ToTerm(","), parameter);

            parameter.Rule = qualified_type + identifierToken;

            method_body.Rule = block
                | semi_colon
                ;

            block.Rule = ToTerm("{") + "}"
                | "{" + statements + "}"
                ;

            // Dichiarazione Proprietà

            property_declaration.Rule = visibility_modifiers + qualified_type + identifierToken + property_body;

            property_body.Rule = "{" + "}";

            // Statements

            statements.Rule = MakePlusRule(statements, null, statement);

            statement.Rule = declaration_statement
                | embedded_statement                
                ;

            embedded_statement.Rule = block
                | if_statement
                | switch_statement
                | for_statement
                | foreach_statement
                | do_statement
                | while_statement
                ;

            // If Statement

            if_statement.Rule = ToTerm("if") + "(" + expression + ")" + embedded_statement + else_statement;

            else_statement.Rule = Empty
                | PreferShiftHere() + "else" + embedded_statement
                ;

            // For Statement

            for_statement.Rule = ToTerm("for") + "(" + for_initializer + ";" + for_condition + ";" + for_iterator + ")" + embedded_statement;

            for_initializer.Rule = Empty
                | assign_statement
                | variable_declaration
                ;

            for_condition.Rule = Empty
                | expression
                ;

            for_iterator.Rule = Empty
                | inc_or_dec_operator + qualified_identifier
                | qualified_identifier + inc_or_dec_operator
                ;

            // Foreach Statement

            foreach_statement.Rule = ToTerm("foreach") + "(" + type_declaration + identifierToken + "in" + qualified_identifier + ")" + embedded_statement;

            // Do Statement

            do_statement.Rule = ToTerm("do") + embedded_statement + "while" + "(" + expression + ")" + ";";

            // While Statement

            while_statement.Rule = ToTerm("while") + "(" + expression + ")" + embedded_statement;

            // Switch Statement

            switch_statement.Rule = ToTerm("switch") + "(" + expression + ")" + "{" + switch_body + "}";

            switch_body.Rule = MakeStarRule(switch_sections, null, switch_section);

            switch_section.Rule = ToTerm("case") + expression + ":" + expression + "break" + ";"
                | ToTerm("default") + ":" + expression + "break" + ";"
                ;

            // Dichiarazione di variabili

            declaration_statement.Rule = qualified_type + variable_declarations + ";"
                ;

            variable_declarations.Rule = MakePlusRule(variable_declarations, ToTerm(","), variable_declaration);

            variable_declaration.Rule = identifierToken
                | identifierToken + "=" + expressions
                ;

            // Espressione creazione oggetti

            //object_creation_expression.Rule = 

            // Espressione matematica

            math_expression.Rule = element + binary_operator + expressions;

            relational_expression.Rule = element + binary_operator + expressions;

            // Assegnazione

            assign_statement.Rule = qualified_identifier + assignment_operator + expressions + ";";

            // Operatori

            unary_operator.Rule = ToTerm("+") | "-" | "!" | "~" | "*";
            assignment_operator.Rule = ToTerm("=") | "+=" | "-=" | "*=";
            binary_operator.Rule = ToTerm("<")
                  | "||" | "&&" | "|" | "^" | "&" 
                  | "==" | "!=" | ">" | "<=" | ">=" | "<<" | ">>" | "+" | "-" | "*" | "/"
                  | "=" | "+=" | "-=" | "*="
                  | "is" | "as" | "??"
                  ;
            inc_or_dec_operator.Rule = ToTerm("++") | "--";

            // Espressione

            expressions.Rule = MakeStarRule(expressions, null, expression);

            expression.Rule = element
                //| math_expression // conflict
                ;

            // Elementi

            boolean_token.Rule = ToTerm("true")
                | "false"
                ;

            object_token.Rule = qualified_identifier
                //| qualified_identifier + function_arguments // confict
                ;
            
            function_arguments.Rule = ToTerm("(") + ")"
                | "(" + arguments + ")"
                ;

            arguments.Rule = MakePlusRule(arguments, ToTerm(","), argument)
                ;

            argument.Rule = element;

            element.Rule = object_token
                | stringToken
                | numberToken
                | boolean_token
                | "null"
                | "(" + expression + ")"
                ;

            #region AST

            // Definizione dei simboli di punteggiatura da eliminare nella costruzione dell'AST

            this.MarkPunctuation(
                "(",")",
                ",", ";",
                "{", "}",
                "[", "]",
                "."
                );

            // Registra le regole di precedenza degli operatori

            this.RegisterOperators(50, "*", "/");
            this.RegisterOperators(40, "+", "-");
            this.RegisterOperators(30, "=", "<=", ">=", "<", ">", "<>");
            this.RegisterOperators(20, "&&", "||");

            //this.LanguageFlags = LanguageFlags.CreateAst | LanguageFlags.NewLineBeforeEOF;

            #endregion

        }
    }
}
