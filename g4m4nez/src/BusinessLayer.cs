using System.Collections.Generic;
using System;
namespace BusinessLayer
{
    public class BusinessLayer
    {
        private Dictionary<Guid, User> Users;
        private Dictionary<Guid, Wallet> Wallets;
        private Dictionary<User, List<Wallet>> UserToWallets = new Dictionary<User, List<Wallet>>();
        private Dictionary<Wallet, List<User>> WalletToUsers = new Dictionary<Wallet, List<User>>();

        public void CreateUser(PersonName name, Email email)
        {
            User user = new User(name, email);
            Users[Guid.NewGuid()] = user;
            UserToWallets[user] = new List<Wallet>();
        }

        public void CreateWallet(Guid userID, string name, decimal startingBalance, Money.Currencies currency)
        {
            User owner = Users[userID];
            Wallet wallet = new Wallet(owner, name, startingBalance, currency);
            Wallets[Guid.NewGuid()] = wallet;
            WalletToUsers[wallet].Add(owner);
        }

        public void RenameWallet(Guid userID, Guid walletID, string name)
        {
            User user = Users[userID];
            Wallet wallet = Wallets[walletID];
            if (wallet.IsOwner(user))
            {
                wallet.Name = name;
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can change wallet name");
            }
        }

        public void ChangeWalletDescription(Guid userID, Guid walletID, string description)
        {
            User user = Users[userID];
            Wallet wallet = Wallets[walletID];
            if (wallet.IsOwner(user))
            {
                wallet.Description = description;
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can change wallet description");
            }
        }

        public void CreateTransaction(Guid userID, Guid walletID, Money amount, 
            string description, Category category, DateTime date)
        {
            User user = Users[userID];
            Wallet wallet = Wallets[walletID];
            Transaction transaction = new Transaction(user, amount, description, category, date);
            wallet.AddTransaction(transaction);
        }

        public void CreateTransaction(Guid userID, Guid walletID, Money amount,
            string description, Category category, DateTime date, List<string> attachments)
        {
            User user = Users[userID];
            Wallet wallet = Wallets[walletID];
            Transaction transaction = new Transaction(user, amount, description, category, date, attachments);
            wallet.AddTransaction(transaction);
        }

        public void CreateCategory(Guid userID, string name, string description, string icon, Category.Colors color)
        {
            User user = Users[userID];
            Category category = new Category(name, description, icon, color);
            user.Categories.AddCategory(category);
        }

        public void AddCategory(Guid userID, Guid walletID, Category category)
        {
            User user = Users[userID];
            Wallet wallet = Wallets[walletID];
            if (wallet.IsOwner(user))
            {
                wallet.Categories.ActivateCategory(category);
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can activate wallet categories");
            }
        }

        public void RemoveCategory(Guid userID, Guid walletID, Category category)
        {
            User user = Users[userID];
            Wallet wallet = Wallets[walletID];
            if (wallet.IsOwner(user))
            {
                wallet.Categories.DeactivateCategory(category);
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can deactivate wallet categories");
            }
        }
    }
}
