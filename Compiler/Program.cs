using System;
using System.Collections.Generic;
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

            var argManager = new ArgManager(new string[] { "source.cs", "-d" });
            //var argManager = new ArgManager(args);

            List<string> Files = new List<string>();
            List<string> Scripts = new List<string>();

            string output_dir = string.Empty;
            if (argManager.Find("-o") != null)
                output_dir = argManager.Find("-o");

            foreach(var arg in argManager.FindAll())
            {
                if (File.Exists(arg) || Directory.Exists(arg))
                {
                    var attr = File.GetAttributes(arg);
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        // is folder
                        Files.AddRange(Directory.GetFiles(arg, "*.cs", SearchOption.AllDirectories));
                    }
                    else
                    {
                        // is file
                        Files.Add(arg);
                    }
                }
                else Console.WriteLine("Argument exception: " + arg);
            }

            JavascriptGenerator compiler = new JavascriptGenerator(new SharpGrammar());

            foreach (var filename in Files)
            {
                Console.WriteLine("Compiling file: " + filename);

                string source = File.ReadAllText(filename);

                if (compiler.Parse(source) == false)
                {
                    Console.WriteLine(compiler.Errors);
                    Console.WriteLine(compiler.AbstractSyntaxTree.Errors);
                    break;
                }

                string output = compiler.Compile();
                Console.WriteLine("Compile output:");
                Console.WriteLine(output);

                string out_filename = filename.Replace(".cs", ".js");
                if(string.IsNullOrEmpty(output_dir) == false)
                {
                    if (Directory.Exists(output_dir) == false)
                        Directory.CreateDirectory(output_dir);
                    out_filename = output_dir.Trim('/') + "/" + Path.GetFileName(out_filename);
                }
                Scripts.Add(out_filename);

                StreamWriter wr = new StreamWriter(out_filename);
                wr.Write(output);
                wr.Close();
                wr.Dispose();
            }            

            if(argManager.Contains("-d") == true)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("<html>");
                str.AppendLine("\t<title>SharpToJs Debug</title>");
                foreach(var script in Scripts)
                {
                    str.AppendLine("\t<script type = 'text/javascript' src = '" + Path.GetFileName(script) + "'></script>");
                }
                str.AppendLine("<body>");

                var main = SharpToJs.AST.MainNode.singleton;
                if (main != null)
                {
                    str.AppendLine("<script>");
                    str.AppendLine(main.ToScript());
                    str.AppendLine("</script>");
                }

                str.AppendLine("</body>");
                str.AppendLine("</html>");

                string output_filename = "index.html";
                if (string.IsNullOrEmpty(output_dir) == false)
                {
                    output_filename = output_dir.Trim('/') + "/index.html";
                }

                var out_file = new StreamWriter(output_filename);
                out_file.Write(str.ToString());
                out_file.Close();
                out_file.Dispose();

                Console.WriteLine("Debug: " + output_filename);
                Console.WriteLine(str.ToString());

                Console.ReadKey();
            }
        }
    }
}
