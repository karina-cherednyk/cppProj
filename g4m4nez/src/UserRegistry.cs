using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace g4m4nez.BusinessLayer
{
    public class UserRegistry
    {
        private Guid _owner;
        public Guid Owner => _owner;

        private readonly List<Guid> _users;
        public List<Guid> Users => _users;

        public UserRegistry(Guid owner)
        {
            _owner = owner;
            _users = new List<Guid>();
        }        
        
        [JsonConstructor]
        public UserRegistry(Guid owner, List<Guid> users)
        {
            _owner = owner;
            _users = users;
        }

        public void AddUser(Guid user)
        {
            _users.Add(user);
        }

        public void RemoveUser(Guid user)
        {
            _users.Remove(user);
        }
    }
}