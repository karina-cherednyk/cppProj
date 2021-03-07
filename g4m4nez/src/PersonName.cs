namespace BusinessLayer
{
    public struct PersonName
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public PersonName(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}