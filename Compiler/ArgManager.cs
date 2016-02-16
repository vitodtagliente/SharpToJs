using System.Collections.Generic;

namespace Compiler
{
    public class ArgManager
    {
        string[] args;

        public ArgManager(string[] args)
        {
            this.args = args;
        }

        public bool Contains(string flagName)
        {
            foreach (var arg in args)
                if (arg.Equals(flagName))
                    return true;
            return false;
        }

        public string Find(string argType)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Trim().ToLower().Equals(argType.Trim().ToLower()))
                {
                    if (i >= args.Length || args[i + 1].Trim().StartsWith("-")) return null;
                    return args[i + 1];
                }
            }
            return null;
        }

        public List<string> FindAll()
        {
            List<string> list = new List<string>();
            foreach(var arg in args)
            {
                if (arg.StartsWith("-"))
                    return list;
                list.Add(arg);
            }
            return list;
        }
    }
}
