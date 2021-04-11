using g4m4nez.DataAccessLayer;
using g4m4nez.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace g4m4nez.BusinessLayer
{
    [Serializable]
    public class Wallet : IStorable
    {
        private readonly FileDataStorage<DBUser> _dbUsers = new FileDataStorage<DBUser>();

        private Guid _guid;
        private decimal _startingBalance;
        private string _name;
        private string _description;
        private Money.Currencies _currency;
        private readonly TransactionChain _transactions;
        private readonly WalletCategories _categories;
        private readonly UserRegistry _users;


        public Guid Guid
        {
            get => _guid;
            set => _guid = value;
        }
        public decimal StartingBalance
        {
            get => _startingBalance;
            set => _startingBalance = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public Money.Currencies Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        public TransactionChain Transactions
        {
            get { return _transactions; }
        }
        public WalletCategories Categories
        {
            get { return _categories; }
        }
        public UserRegistry Users
        {
            get { return _users; }

        }

        public async void AddUser(Guid userGuid)
        {
            Users.AddUser(userGuid);
            User user = new(await _dbUsers.GetAsync(userGuid));
            Categories.AddUserCategories(new(await _dbUsers.GetAsync(userGuid)));
        }

        public void RemoveUser(Guid userGuid)
        {
            Users.RemoveUser(userGuid);
        }

        public void AddCategory(Category category)
        {
            Categories.AddCategory(category);
        }

        public void RemoveCategory(Category category)
        {
            Categories.RemoveCategory(category);
        }

        public void CreateTransaction(Transaction transaction)
        {
            Transactions.AddTransaction(transaction);
        }

        public List<Transaction> GetLastNTransactions(int n = 10)
        {
            return Transactions.GetLastNTransactions(n);
        }

        public List<Transaction> GetFromIndex(int index)
        {
            return Transactions.GetFromIndex(index);
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.AddTransaction(transaction);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            Transactions.RemoveTransaction(transaction);
        }

        public bool IsOwner(User user)
        {
            return user.Guid == Users.Owner;
        }

        public Wallet(Guid ownerGuid, string name, string description, decimal startingBalance, Money.Currencies currency)
        {
            _guid = Guid.NewGuid();

            _users = new UserRegistry(ownerGuid);
            _transactions = new TransactionChain(_currency);

            // TODO: impl guid/repo for categories
            //DBUser owner        = Task.Run<DBUser>(async () => await _dbUsers.GetAsync(ownerGuid)).Result;
            //this._categories    = new WalletCategories(owner.Categories.Categories);

            Name = name;
            Description = description;
            _startingBalance = startingBalance;
            _currency = currency;
        }

        [JsonConstructor]
        public Wallet(string name, string description, decimal startingBalance, Money.Currencies currency,
            Guid guid, UserRegistry users, TransactionChain transactions, WalletCategories categories)
        {
            _guid = guid;

            _users = users;
            _transactions = transactions;
            _categories = categories;

            Name = name;
            Description = description;
            _startingBalance = startingBalance;
            _currency = currency;
        }

    }
}