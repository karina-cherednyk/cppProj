namespace g4m4nez.Models
{
    public struct Category
    {
        private string _icon;
        public string Icon
        {
            get => _icon;
            set => _icon = value;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public enum Colors
        {
            BLUE, ORANGE, BLACK, CYAN, MAGENTA
        }

        private Colors _color;
        public Colors Color
        {
            get => _color;
            set => _color = value;
        }

        public Category(string name, string description, string icon, Colors color)
        {
            _name = name;
            _description = description;
            _icon = icon;
            _color = color;
        }

        public Category(string name, string icon, Colors color)
        {
            _name = name;
            _description = "";
            _icon = icon;
            _color = color;
        }
    }
}