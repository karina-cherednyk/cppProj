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

        //public async Task<Wallet> CreateWallet(Guid userID, string name, string description, decimal startingBalance, Money.Currencies currency)
        //{
        //    DBUser dbOwner = await _dbUsers.GetAsync(userID);

        //    Wallet wallet = new(dbOwner.Guid, name, description, startingBalance, currency);
        //    await AddOrUpdateWalletAsync(wallet);

        //    dbOwner.Wallets.AddOwnedWallet(wallet.Guid);
        //    await _dbUsers.AddOrUpdateAsync(dbOwner);

        //    return wallet;
        //}

        public async Task<Wallet> CreateWallet(Guid userID, Wallet wallet)
        {
            DBUser dbOwner = await _dbUsers.GetAsync(userID);
            await AddOrUpdateWalletAsync(wallet);

            dbOwner.Wallets.AddOwnedWallet(wallet.Guid);
            await _dbUsers.AddOrUpdateAsync(dbOwner);

            return wallet;
        }

        public async Task<Transaction> CreateTransaction(Guid userID, Guid walletID, Money amount, string description,
                                            Category category, DateTime date)
        {
            Wallet wallet = await _wallets.GetAsync(walletID);
            Transaction transaction = new(userID, amount, description, category, date);
            wallet.AddTransaction(transaction);
            await _wallets.AddOrUpdateAsync(wallet); // TODO: may be buggy
            return transaction;
        }

        public async Task<Transaction> CreateTransaction(Guid userID, Guid walletID, Money amount, string description,
                                            Category category, DateTime date, List<string> attachments)
        {
            Wallet wallet = await _wallets.GetAsync(walletID);
            Transaction transaction = new(userID, amount, description, category, date, attachments);
            wallet.AddTransaction(transaction);
            await _wallets.AddOrUpdateAsync(wallet); // TODO: may be buggy
            return transaction;
        }

        public async void CreateCategory(Guid userID, string name, string description, string icon, Category.Colors color)
        {
            DBUser user = await _dbUsers.GetAsync(userID);
            Category category = new(name, description, icon, color);
            user.Categories.AddCategory(category);
            await _dbUsers.AddOrUpdateAsync(user); // TODO: may be buggy
        }

        // Adds category to wallet
        public async void AddCategory(Guid userID, Guid walletID, Category category)
        {
            Wallet wallet = await _wallets.GetAsync(walletID);
            if (wallet.IsOwner(userID)) // TODO: may be buggy
            {
                wallet.Categories.ActivateCategory(category);
                await _wallets.AddOrUpdateAsync(wallet);
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can activate wallet categories");
            }
        }

        public async void RemoveCategory(Guid userID, Guid walletID, Category category)
        {
            Wallet wallet = await _wallets.GetAsync(walletID);
            if (wallet.IsOwner(userID)) // TODO: may be buggy
            {
                wallet.Categories.DeactivateCategory(category);
                await _wallets.AddOrUpdateAsync(wallet);
            }
            else
            {
                throw new System.InvalidOperationException("Only owner can deactivate wallet categories");
            }
        }

        public async void RemoveTransaction(Guid userID, Guid walletID, Transaction transaction)
        {
            Wallet wallet = await _wallets.GetAsync(walletID);
            if (transaction.User == userID || wallet.IsOwner(userID))
            {
                wallet.Transactions.RemoveTransaction(transaction);
                await _wallets.AddOrUpdateAsync(wallet);
            }
            else
            {
                throw new System.InvalidOperationException("You're not allowed to remove this transaction!");
            }

        }
    }
}
