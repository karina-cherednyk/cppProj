using System.Collections.Generic;
namespace BusinessLayer
{
    public class Wallet
    {

        private decimal startingBalance;
        public decimal StartingBalance
        {
            get { return startingBalance; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private Money.Currencies currency;
        public Money.Currencies Currency
        {
            get { return currency; }
        }

        private TransactionChain transactions;
        public TransactionChain Transactions
        {
            get { return transactions; }
        }

        private WalletCategories categories;
        public WalletCategories Categories
        {
            get { return categories; }
        }

        private UserRegistry users;
        public UserRegistry Users
        {
            get { return users; }
        }

        public void AddUser(User user)
        {
            Users.AddUser(user);
            Categories.AddUserCategories(user);
        }

        public void RemoveUser(User user)
        {
            Users.RemoveUser(user);
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

        public Wallet(User owner, string name, decimal startingBalance, Money.Currencies currency)
        {
            users = new UserRegistry(owner);
            Name = name;
            this.startingBalance = startingBalance;
            this.currency = currency;

            categories = new WalletCategories(owner.Categories.Categories);
        }

    }
}