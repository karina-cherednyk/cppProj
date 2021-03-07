namespace BusinessLayer
{
    public class Category
    {
        private string icon;
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description = "";
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public enum Colors
        {
            BLUE, ORANGE, BLACK, CYAN, MAGENTA
        }

        private Colors color;
        public Colors Color
        {
            get { return color; }
            set { color = value; }
        }

        public Category(string name, string description, string icon, Colors color)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Color = color;
        }

        public Category(string name, string icon, Colors color)
        {
            Name = name;
            Icon = icon;
            Color = color;
        }
    }
}