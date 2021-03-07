using System.Collections.Generic;
namespace BusinessLayer
{
    public class User
    {
        private PersonName name;
        public PersonName Name
        {
            get { return name; }
            set { name = value; }
        }


        private Email email;
        public Email Email
        {
            get { return email; }
            set { email = value; }
        }

        private UserCategories categories;
        public UserCategories Categories
        {
            get { return categories; }
        }

        public User(PersonName name, Email email)
        {
            Name = name;
            Email = email;
            categories = new UserCategories();
        }
    }
}