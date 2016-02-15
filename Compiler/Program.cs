using System;
using System.IO;
using SharpToJs;
using System.Text;

namespace Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SharpToJs Compiler";

            var argManager = new ArgManager(args);

            string filename = "source.txt";
            string source = File.ReadAllText(filename);

            JavascriptGenerator compiler = new JavascriptGenerator(new SharpGrammar());
            if (compiler.Parse(source) == false)
            {
                Console.WriteLine(compiler.Errors);
                Console.WriteLine(compiler.AbstractSyntaxTree.Errors);
                return;
            }

            string output = compiler.Compile();
            Console.WriteLine(output);

            var pieces = filename.Split('.');
            string out_filename = pieces[0] + ".js";

            StreamWriter wr = new StreamWriter(out_filename);
            wr.Write(output);
            wr.Close();
            wr.Dispose();

            if(argManager.Contains("-d") == false)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("<html>");
                str.AppendLine("\t<title>SharpToJs Debug</title>");
                str.AppendLine("<script type = 'text/javascript' src = '" + out_filename + "'></script>");
                str.AppendLine("<body");

                str.AppendLine("</body>");
                str.AppendLine("</html>");

                var out_file = new StreamWriter("index.html");
                out_file.Write(str.ToString());
                out_file.Close();
                out_file.Dispose();
            }

            Console.ReadKey();
        }
    }
}
