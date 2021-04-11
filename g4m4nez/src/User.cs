using g4m4nez.DataAccessLayer;
using g4m4nez.Models;
using System;

namespace g4m4nez.BusinessLayer
{
    public class User : IStorable
    {
        private Guid _guid;
        private string _login;
        private PersonName _name;
        private Email _email;
        private readonly UserCategories _categories;
        private readonly WalletRegistry _wallets;
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }
        public string Login
        {
            get => _login;
            set => _login = value;
        }
        public PersonName Name
        {
            get => _name;
            set => _name = value;
        }
        public Email Email
        {
            get => _email;
            set => _email = value;
        }
        public UserCategories Categories => _categories;
        public WalletRegistry Wallets => _wallets;
        public User(PersonName name, Email email)
        {
            Name = name;
            Email = email;
            _categories = new UserCategories();
        }

        public User(Guid guid, PersonName name, Email email, string login)
        {
            _guid = guid;
            Name = name;
            Email = email;
            Login = login;
            _categories = new();
            _wallets = new();
        }

        public User(DBUser other)
        {
            _guid = other.Guid;
            Name = other.Name;
            Email = other.Email;
            Login = other.Login;
            _categories = other.Categories;
            _wallets = other.Wallets;
        }

    }
}