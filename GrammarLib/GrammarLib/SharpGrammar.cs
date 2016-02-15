using Irony.Parsing;

namespace SharpToJs
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
            CommentTerminal inlineJsStatement = new CommentTerminal("inline-js", "$",
                "\r", "\n", "\u2085", "\u2028", "\u2029");
            NonGrammarTerminals.Add(blockComment);
            NonGrammarTerminals.Add(lineComment);
            NonGrammarTerminals.Add(inlineJsStatement);

            Terminal numberToken = new NumberLiteral("number-token");
            numberToken.AstConfig.NodeType = typeof(AST.NumberNode);
            Terminal stringToken = new StringLiteral("string-token", "\"", StringOptions.None);
            stringToken.AstConfig.NodeType = typeof(AST.StringNode);
            Terminal identifierToken = new IdentifierTerminal("identifier-token");
            identifierToken.AstConfig.NodeType = typeof(AST.IdentifierToken);
                                    
            #endregion

            #region NonTerminals

            NonTerminal program = new NonTerminal("program", typeof(AST.ProgramNode));


            NonTerminal using_directives_lines = new NonTerminal("using-directives-lines");
            NonTerminal using_directives = new NonTerminal("using-directives");
            NonTerminal using_directive = new NonTerminal("using-directive");
            
            NonTerminal namespace_declarations = new NonTerminal("namespace-declarations", typeof(AST.JsNode));
            NonTerminal namespace_declaration = new NonTerminal("namespace-declaration", typeof(AST.NamespaceNode));
            NonTerminal namespace_body = new NonTerminal("namespace-body", typeof(AST.JsNode));

            NonTerminal namespace_member_declarations = new NonTerminal("namespace-member-declarations", typeof(AST.JsNode));
            NonTerminal namespace_member_declaration = new NonTerminal("namespace-member-declaration", typeof(AST.JsNode));

            NonTerminal qualified_identifier = new NonTerminal("qualified-identifier", typeof(AST.QualifiedIdentifierNode));

            NonTerminal semi_colon = new NonTerminal("semi-colon");

            NonTerminal type_declaration = new NonTerminal("type-declaration", typeof(AST.JsNode));

            NonTerminal class_declaration = new NonTerminal("class-declaration", typeof(AST.ClassNode));
            NonTerminal struct_declaration = new NonTerminal("struct-declaration");
            NonTerminal interface_declaration = new NonTerminal("interface-declaration");
            NonTerminal enum_declaration = new NonTerminal("enum-declaration");

            NonTerminal class_body = new NonTerminal("class-body", typeof(AST.ClassBodyNode));

            NonTerminal visibility_modifiers = new NonTerminal("visibility-modifiers", typeof(AST.VisibilityModifierNode));
            NonTerminal visibility_modifier = new NonTerminal("visibility-modifier", typeof(AST.KeywordNode));

            NonTerminal class_params = new NonTerminal("class-params");
            NonTerminal class_param = new NonTerminal("class-param");

            NonTerminal enum_elements = new NonTerminal("enum-elements");
            NonTerminal enum_element = new NonTerminal("enum-element");

            NonTerminal struct_elements = new NonTerminal("struct-elements");

            NonTerminal member_declarations = new NonTerminal("member-declarations", typeof(AST.JsNode));
            NonTerminal member_declaration = new NonTerminal("member-declaration", typeof(AST.JsNode));

            NonTerminal constant_declaration = new NonTerminal("constant-declaration");
            NonTerminal constant_declarators = new NonTerminal("constant-declarators");
            NonTerminal constant_declarator = new NonTerminal("constant-declarator");

            NonTerminal field_declaration = new NonTerminal("field-declaration", typeof(AST.FieldNode));
            NonTerminal constructor_declaration = new NonTerminal("constructor-declaration", typeof(AST.ConstructorNode));
            NonTerminal method_declaration = new NonTerminal("method-declaration", typeof(AST.MethodNode));
            NonTerminal property_declaration = new NonTerminal("property-declaration", typeof(AST.PropertyNode));

            NonTerminal method_parameters = new NonTerminal("method-parameters", typeof(AST.JsNode));
            NonTerminal parameters = new NonTerminal("parameters", typeof(AST.ParametersNode));
            NonTerminal parameter = new NonTerminal("parameter", typeof(AST.JsNode));

            NonTerminal method_body = new NonTerminal("method-body", typeof(AST.JsNode));
            NonTerminal block = new NonTerminal("block", typeof(AST.BlockNode));

            NonTerminal property_body = new NonTerminal("property-body", typeof(AST.JsNode));
            NonTerminal property_labels = new NonTerminal("property-labels", typeof(AST.JsNode));
            NonTerminal property_set = new NonTerminal("property-set", typeof(AST.SetNode));
            NonTerminal property_get = new NonTerminal("property-get", typeof(AST.GetNode));

            NonTerminal builtin_type = new NonTerminal("builtin-type", typeof(AST.JsNode));
            NonTerminal builtin_type_or_void = new NonTerminal("builtin-type-or-void", typeof(AST.JsNode));
            NonTerminal qualified_type = new NonTerminal("qualified-type", typeof(AST.JsNode));

            NonTerminal statements = new NonTerminal("statements", typeof(AST.JsNode));
            NonTerminal statement = new NonTerminal("statement", typeof(AST.StatementNode));

            NonTerminal embedded_statement = new NonTerminal("embedded-statement", typeof(AST.JsNode));
            NonTerminal control_flow_statement = new NonTerminal("control-flow-statement", typeof(AST.JsNode));
            NonTerminal declaration_statement = new NonTerminal("declaration-statement", typeof(AST.JsNode));
            NonTerminal if_statement = new NonTerminal("if-statement", typeof(AST.IfStmtNode));
            NonTerminal else_statement = new NonTerminal("else-statement", typeof(AST.ElseStmtNode));
            NonTerminal do_statement = new NonTerminal("do-statement", typeof(AST.DoNode));
            NonTerminal switch_statement = new NonTerminal("switch-statement");
            NonTerminal switch_body = new NonTerminal("switch-body");
            NonTerminal switch_sections = new NonTerminal("switch-section");
            NonTerminal switch_section = new NonTerminal("switch-section");
            NonTerminal foreach_statement = new NonTerminal("foreach-statement");
            NonTerminal for_statement = new NonTerminal("for-statement", typeof(AST.ForNode));
            NonTerminal for_initializer = new NonTerminal("for-initializer", typeof(AST.JsNode));
            NonTerminal for_condition = new NonTerminal("for-condition", typeof(AST.JsNode));
            NonTerminal for_iterator = new NonTerminal("for-iterator", typeof(AST.JsNode));
            NonTerminal while_statement = new NonTerminal("while-statement", typeof(AST.WhileNode));
            NonTerminal return_statement = new NonTerminal("return-statement", typeof(AST.ReturnStmtNode));

            NonTerminal variable_declarations = new NonTerminal("variable-declarations", typeof(AST.JsNode));
            NonTerminal variable_declaration = new NonTerminal("variable-declaration", typeof(AST.DeclarationStatementNode));

            NonTerminal assign_statement = new NonTerminal("assign-statement", typeof(AST.AssignmentStmtNode));
            
            NonTerminal expressions = new NonTerminal("expressions", typeof(AST.JsNode));
            NonTerminal expression = new NonTerminal("expression", typeof(AST.JsNode));

            NonTerminal conditional_expression = new NonTerminal("conditional-expression");
            NonTerminal bin_op_expression = new NonTerminal("bin-op-expression", typeof(AST.JsNode));
            NonTerminal typecast_expression = new NonTerminal("typecast-expression");
            NonTerminal primary_expression = new NonTerminal("primary-expression", typeof(AST.JsNode));

            NonTerminal object_creation_expression = new NonTerminal("object-creation-expression");
            NonTerminal pre_incr_decr_expression = new NonTerminal("pre-incr-decr-expression", typeof(AST.IncrDecrNode));
            NonTerminal post_incr_decr_expression = new NonTerminal("post-incr-decr-expression", typeof(AST.IncrDecrNode));
            NonTerminal typeof_expression = new NonTerminal("typeof-expression");
            NonTerminal unary_expression = new NonTerminal("unary-expression", typeof(AST.JsNode));
            NonTerminal member_expression = new NonTerminal("member-expression", typeof(AST.MemberExpressionNode));

            NonTerminal unary_operator = new NonTerminal("unary-operator", "operator", typeof(AST.OperatorNode));
            NonTerminal assignment_operator = new NonTerminal("assignment-operator", "assignment operator", typeof(AST.OperatorNode));
            NonTerminal binary_operator = new NonTerminal("binary-operator", "operator", typeof(AST.OperatorNode));
            NonTerminal incr_dec_operator = new NonTerminal("incr-dec-operator", "operator", typeof(AST.OperatorNode));

            NonTerminal boolean_token = new NonTerminal("boolean-token", typeof(AST.BooleanNode));
            NonTerminal object_token = new NonTerminal("object-token", typeof(AST.ObjectNode));

            NonTerminal element = new NonTerminal("element", typeof(AST.JsNode));
            NonTerminal builtin_element = new NonTerminal("builtin-element", typeof(AST.JsNode));

            NonTerminal function_arguments = new NonTerminal("function-arguments", typeof(AST.FunctionArgumentsNode));
            NonTerminal arguments = new NonTerminal("arguments", typeof(AST.ArgumentsNode));
            NonTerminal argument = new NonTerminal("argument", typeof(AST.ArgumentNode));

            #endregion

            #region Keywords

            this.MarkReservedWords(
                "return",
                "int", "string", "float", "void", "double", "long",
                "if", "do", "while", "for", "switch", "case", "break", 
                "using"
                //, "this", "base"
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

            visibility_modifier.Rule = PreferShiftHere() + ToTerm("public")
                | "static"
                | "private"
                | "protected"
                | "virtual"
                | "abstract"
                | "override"
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
                | constructor_declaration
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
                | identifierToken + "=" + builtin_element 
                ;

            // Dichiarazione Attribbuti

            field_declaration.Rule = visibility_modifiers + qualified_type + identifierToken + ";"
                | visibility_modifiers + qualified_type + identifierToken + "=" + primary_expression + ";" // ? primary_expression ? 
                ;

            // Dichiarazione Costruttore

            constructor_declaration.Rule = visibility_modifiers + qualified_identifier + method_parameters + method_body;

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

            property_body.Rule = ToTerm("{") + "}"
                | ToTerm("{") + property_labels + "}" // ? conflict ?
                ;

            property_labels.Rule = ReduceHere() + property_get + property_set
                | property_set + property_get
                ;

            property_get.Rule = Empty
                | visibility_modifiers + ToTerm("get") + method_body
                ;

            property_set.Rule = Empty
                | visibility_modifiers + ToTerm("set") + method_body
                ;

            // Statements

            statements.Rule = MakePlusRule(statements, null, statement);

            statement.Rule = declaration_statement + semi_colon
                | embedded_statement + semi_colon
                ;

            control_flow_statement.Rule = if_statement
                | switch_statement
                | for_statement
                | foreach_statement
                | do_statement
                | while_statement
                ;

            embedded_statement.Rule = block
                | control_flow_statement
                | assign_statement
                | post_incr_decr_expression
                | pre_incr_decr_expression
                | object_creation_expression
                | member_expression 
                | return_statement
                ;

            // Return statement

            return_statement.Rule = ToTerm("return")
                | PreferShiftHere() + "return" + expression
                | "break"
                | "continue"
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
                | PreferShiftHere() + declaration_statement
                ;

            for_condition.Rule = Empty
                | expression
                ;

            for_iterator.Rule = Empty
                | pre_incr_decr_expression
                | post_incr_decr_expression
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

            declaration_statement.Rule = qualified_type + variable_declarations
                ;

            variable_declarations.Rule = MakePlusRule(variable_declarations, ToTerm(","), variable_declaration);

            variable_declaration.Rule = identifierToken
                | identifierToken + "=" + expressions // ? expressions
                ;
            
            // Assegnazione

            assign_statement.Rule = object_token + assignment_operator + expressions + ";"
                ; // ? expressions ?

            // Operatori

            unary_operator.Rule = ToTerm("!");
            assignment_operator.Rule = ReduceHere() + ToTerm("=")
                | "+=" 
                | "-=" 
                | "*="
                ;

            binary_operator.Rule = PreferShiftHere() + ToTerm("+")
                | "||" | "&&" | "|" | "^" 
                | "==" | "!=" | ">" | "<=" | ">=" | "<" | "-" | "*" | "/"
                ;

            incr_dec_operator.Rule = ReduceHere() + ToTerm("++") | "--";

            // Espressione

            expressions.Rule = MakeStarRule(expressions, null, expression);

            expression.Rule = primary_expression
                | conditional_expression
                | typecast_expression
                | bin_op_expression
                ;

            primary_expression.Rule = element
                | unary_expression
                | object_creation_expression
                | typeof_expression
                ;

            bin_op_expression.Rule = expression + binary_operator + expression;

            typecast_expression.Rule = ToTerm("(") + qualified_type + ")" + primary_expression;

            conditional_expression.Rule = expression + PreferShiftHere() + "?" + expression + ":" + expression;

            unary_expression.Rule = unary_operator + unary_expression;

            pre_incr_decr_expression.Rule = incr_dec_operator + element;

            post_incr_decr_expression.Rule = element + incr_dec_operator;

            typeof_expression.Rule = ToTerm("typeof") + "(" + primary_expression + ")";

            object_creation_expression.Rule = ToTerm("new") + qualified_identifier + function_arguments
                ;

            member_expression.Rule = MakePlusRule(member_expression, ToTerm("."), object_token);
                ;

            // Elementi

            boolean_token.Rule = ToTerm("true")
                | "false"
                ;

            object_token.Rule = qualified_identifier + function_arguments
                ;
            
            function_arguments.Rule = Empty
                | "(" + arguments + ")"
                ;

            arguments.Rule = MakeStarRule(arguments, ToTerm(","), argument)
                ;

            argument.Rule = element;

            element.Rule = object_token
                | PreferShiftHere() + member_expression
                | builtin_element
                | "null"
                | "(" + expression + ")"
                ;

            builtin_element.Rule = numberToken
                | boolean_token
                | stringToken
                ;

            #region AST

            // Definizione dei simboli di punteggiatura da eliminare nella costruzione del Parse Tree

            /*
            this.MarkPunctuation(
                "(",")",
                ",", ";",
                "{", "}",
                "[", "]",
                "."
                );
            */

            // Registra le regole di precedenza degli operatori

            this.RegisterOperators(50, "*", "/");
            this.RegisterOperators(40, "+", "-");
            this.RegisterOperators(30, "=", "<=", ">=", "<", ">", "<>");
            this.RegisterOperators(20, "&&", "||");

            //MarkTransient(unary_operator, binary_operator, incr_dec_operator, assignment_operator);

            MarkTransient(using_directives_lines);
            MarkTransient(namespace_declarations);

            //this.LanguageFlags = LanguageFlags.CreateAst | LanguageFlags.NewLineBeforeEOF;

            #endregion

        }
    }
}
