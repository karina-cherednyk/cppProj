using g4m4nez.BusinessLayer;
using g4m4nez.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class TransactionDetailsViewModel : BindableBase
    {
        private Transaction _transaction;
        private Wallet _wallet;

        public Transaction FromTransaction => _transaction;
        public Wallet FromWallet => _wallet;

        public Money Amount
        {
            get => _transaction.Amount;
            set => _transaction.Amount = value;
        }

        public string Description
        {
            get => _transaction.Description;
            set => _transaction.Description = value;
        }

        public Money.Currencies Currency
        {
            get => _transaction.Currency;
        }

        public Category TransactionCategory
        {
            get => _transaction.TransactionCategory;
            set => _transaction.TransactionCategory = value;
        }

        public DateTime Date
        {
            get => _transaction.Date;
            set => _transaction.Date = value;
        }

        public string DisplayName => $"{Amount.Amount} ({Currency})";

        public TransactionDetailsViewModel(Transaction transaction, Wallet wallet)
        {
            _transaction = transaction;
            _wallet = wallet;
            SubmitChangesCommand = new DelegateCommand(SubmitChanges);
        }

        public DelegateCommand SubmitChangesCommand { get; }
        public async void SubmitChanges()
        {
            await WalletsViewModel._walletSevice.AddOrUpdateWalletAsync(FromWallet);
            RaisePropertyChanged(nameof(DisplayName));
            return;
        }
    }
}
