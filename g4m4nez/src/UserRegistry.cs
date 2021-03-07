using System.Collections.Generic;
namespace BusinessLayer
{
    public class UserRegistry
    {
        private User owner;
        public User Owner
        {
            get { return owner; }
        }

        private HashSet<User> users;
        public HashSet<User> Users
        {
            get { return users; }
        }

        public UserRegistry(User owner)
        {
            this.owner = owner;
            users = new HashSet<User>();
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void RemoveUser(User user)
        {
            users.Remove(user);
        }
    }
}