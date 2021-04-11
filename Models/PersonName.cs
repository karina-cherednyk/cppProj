using System;

namespace g4m4nez.Models
{
    [Serializable]
    public struct PersonName
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _surname;
        public string Surname
        {
            get => _surname;
            set => _surname = value;
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