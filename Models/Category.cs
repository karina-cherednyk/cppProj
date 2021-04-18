using Newtonsoft.Json;

namespace g4m4nez.Models
{
    public class Category
    {
        private string _icon;
        private string _name;
        private string _description;
        private Colors _color;

        public string Icon
        {
            get => _icon;
            set => _icon = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public enum Colors
        {
            BLUE, ORANGE, BLACK, CYAN, MAGENTA
        }

        public Colors Color
        {
            get => _color;
            set => _color = value;
        }

        [JsonConstructor]
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
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Category that = (Category)obj;
                return 
                    that.Name != null && that.Name.Equals(this.Name) && 
                    that.Description != null && that.Description.Equals(this.Description);
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Description.GetHashCode();
        }
    }
}