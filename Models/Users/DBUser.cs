using g4m4nez.DataAccessLayer;
using System;
using System.Text.Json.Serialization;

namespace g4m4nez.Models
{
    [Serializable]
    public class DBUser : IStorable
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid Guid { get; }
        public PersonName Name { get; }
        public Email Email { get; }
        public UserCategories Categories { get; }
        public WalletRegistry Wallets { get; }

        [JsonConstructor]
        public DBUser(Guid guid, PersonName name, Email email, string login, string password, UserCategories categories = null, WalletRegistry wallets = null)
        {
            Guid = guid;
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            Categories = categories ?? (new());
            Wallets = wallets ?? (new());
        }

    }
}
