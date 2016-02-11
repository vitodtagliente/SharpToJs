using Irony.Parsing;
using System;

namespace SharpToJs.AST
{
    public class NodeFactory
    {
        public static object Map(ParseTreeNode node)
        {
            if (node == null) return null;

            try
            {
                var type = node.Term.AstConfig.NodeType;
                var jsnode = Activator.CreateInstance(type);
                ((JsNode)jsnode).Init(node);

                return jsnode;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
