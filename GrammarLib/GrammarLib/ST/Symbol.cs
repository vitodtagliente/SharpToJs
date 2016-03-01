
namespace SharpToJs.ST
{
    public class Symbol
    {
        public string Name { get; private set; }
        public string Type;
        public string Category { get; private set; }
        public string Modifier;
        public string Parent;
        public bool IsPublic
        {
            get { return Modifier.Equals("public"); }
        }
        public string Flags = string.Empty;

        public Symbol(string name, string category)
        {
            Name = name;
            Category = category;
            Modifier = "private";
            Type = string.Empty;
            Parent = string.Empty;
        }

        public Symbol(string name, string category, string modifier)
        {
            Name = name;
            Category = category;
            Modifier = modifier;
            Type = string.Empty;
            Parent = string.Empty;
        }

        public void SetPublic()
        {
            Modifier = "public";
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Category: {1}, Modifier: {2}, Type: {3}, Parent: {4}",
                Name, Category, Modifier, Type, Parent
                );
        }
    }
}
