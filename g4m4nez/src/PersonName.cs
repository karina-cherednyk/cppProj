namespace BusinessLayer
{
    public class PersonName
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public PersonName(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}