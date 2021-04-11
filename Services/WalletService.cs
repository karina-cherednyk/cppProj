using g4m4nez.BusinessLayer;
using g4m4nez.DataAccessLayer;
using g4m4nez.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace g4m4nez.Services
{
    public class WalletService
    {
        private readonly FileDataStorage<DBUser> _dbUsers = new();
        private readonly FileDataStorage<Wallet> _wallets = new();
        public async Task<bool> AddOrUpdateWalletAsync(Wallet wallet)
        {
            Thread.Sleep(1000);
            await _wallets.AddOrUpdateAsync(wallet);
            return true;
        }
        public void DeleteWallet(Wallet wallet)
        {
            Thread.Sleep(1000);
            _wallets.Delete(wallet);
        }
        public List<Wallet> GetWallets()
        {
            Task<List<Wallet>> wallets = Task.Run<List<Wallet>>(async () => await _wallets.GetAllAsync());
            return wallets.Result;
        }

        public async Task<Wallet> CreateWallet(Guid userID, string name, string description, decimal startingBalance, Money.Currencies currency)
        {
            DBUser dbOwner = await _dbUsers.GetAsync(userID);

            Wallet wallet = new(dbOwner.Guid, name, description, startingBalance, currency);
            await AddOrUpdateWalletAsync(wallet);

            dbOwner.Wallets.AddOwnedWallet(wallet.Guid);
            await _dbUsers.AddOrUpdateAsync(dbOwner);

            return wallet;
        }

        public async void RenameWallet(Guid userID, Guid walletID, string name)
        {
            User user = new(await _dbUsers.GetAsync(userID));
            Wallet wallet = await _wallets.GetAsync(walletID);
            if (wallet.IsOwner(user))
            {
                wallet.Name = name;
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can change wallet name");
            }
        }

        public async void ChangeWalletDescription(Guid userID, Guid walletID, string description)
        {
            User user = new(await _dbUsers.GetAsync(userID));
            Wallet wallet = await _wallets.GetAsync(walletID);
            if (wallet.IsOwner(user))
            {
                wallet.Description = description;
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can change wallet description");
            }
        }

        public async void CreateTransaction(Guid userID, Guid walletID, Money amount,
            string description, Category category, DateTime date)
        {
            User user = new(await _dbUsers.GetAsync(userID));
            Wallet wallet = await _wallets.GetAsync(walletID);
            Transaction transaction = new(user, amount, description, category, date);
            wallet.AddTransaction(transaction);
        }

        public async void CreateTransaction(Guid userID, Guid walletID, Money amount,
            string description, Category category, DateTime date, List<string> attachments)
        {
            User user = new(await _dbUsers.GetAsync(userID));
            Wallet wallet = await _wallets.GetAsync(walletID);
            Transaction transaction = new(user, amount, description, category, date, attachments);
            wallet.AddTransaction(transaction);
        }

        public async void CreateCategory(Guid userID, string name, string description, string icon, Category.Colors color)
        {
            User user = new(await _dbUsers.GetAsync(userID));
            Category category = new(name, description, icon, color);
            user.Categories.AddCategory(category);
        }

        public async void AddCategory(Guid userID, Guid walletID, Category category)
        {
            User user = new(await _dbUsers.GetAsync(userID));
            Wallet wallet = await _wallets.GetAsync(walletID);
            if (wallet.IsOwner(user))
            {
                wallet.Categories.ActivateCategory(category);
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can activate wallet categories");
            }
        }

        public async void RemoveCategory(Guid userID, Guid walletID, Category category)
        {
            User user = new(await _dbUsers.GetAsync(userID));
            Wallet wallet = await _wallets.GetAsync(walletID);
            if (wallet.IsOwner(user))
            {
                wallet.Categories.DeactivateCategory(category);
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can deactivate wallet categories");
            }
        }

        public async void RemoveTransaction(Guid userID, Guid walletID, Transaction transaction)
        {
            User user = new(await _dbUsers.GetAsync(userID));
            Wallet wallet = await _wallets.GetAsync(walletID);
            if (transaction.User == user || wallet.IsOwner(user))
            {
                wallet.Transactions.RemoveTransaction(transaction);
            }
            else
            {
                throw new System.InvalidOperationException("You're not allowed to remove this transaction!");
            }

        }
    }
}
