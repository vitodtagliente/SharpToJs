using System;
using System.IO;
using SharpToJs;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SharpToJs Compiler";

            string filename = "source.txt";
            string source = File.ReadAllText(filename);

            JavascriptGenerator compiler = new JavascriptGenerator(new SharpGrammar());
            //source = "2+4";
            if (compiler.Parse(source) == false)
            {
                Console.WriteLine(compiler.Errors);
                Console.WriteLine(compiler.AbstractSyntaxTree.Errors);
            }

            string output = compiler.Compile();
            Console.WriteLine(output);

            Console.ReadKey();
        }
    }
}
