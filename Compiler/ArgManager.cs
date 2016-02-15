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

        public string First()
        {
            if (args.Length < 1) return null;
            if (!string.IsNullOrEmpty(args[0]) && args[0].Trim() != "-")
                return args[0];
            return null;
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

        public List<string> FindAll(string argType)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Trim().ToLower().Equals(argType.Trim().ToLower()))
                {
                    int y = i + 1;
                    while (y < args.Length && !args[y].Trim().StartsWith("-"))
                    {
                        list.Add(args[y]);
                        y++;
                    }

                    if (list.Count > 0)
                        return list;
                    return null;
                }
            }
            return null;
        }
    }
}
