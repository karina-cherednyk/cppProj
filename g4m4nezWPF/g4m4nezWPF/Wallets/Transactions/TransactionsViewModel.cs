﻿
using g4m4nez.BusinessLayer;
using g4m4nez.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class TransactionsViewModel : BindableBase
    {
        private readonly WalletService _service = new();

        private readonly Wallet _wallet;

        private TransactionDetailsViewModel _currentTransaction;

        public DelegateCommand AddTransactionCommand { get; }
        public DelegateCommand DeleteTransactionCommand { get; }

        public TransactionDetailsViewModel CurrentTransaction
        {
            get =>  _currentTransaction;
            set
            {
                _currentTransaction = value;
                RaisePropertyChanged();
            }
        }

        public async void EditTransaction()
        {
            await _service.AddOrUpdateWalletAsync(_wallet);
        }


        public static ObservableCollection<TransactionDetailsViewModel> Transactions { get; set; }

        public void UpdateWalletTransactions()
        {
            Transactions.Clear();
            foreach (Transaction tran in _wallet.GetLastNTransactions(10))
            {
                Transactions.Add(new TransactionDetailsViewModel(tran, _wallet));
            }
        }

        public void DeleteTransaction()
        {
            _service.RemoveTransaction(CurrentSession.User.Guid, _wallet.Guid, CurrentTransaction.FromTransaction);
        }

        public TransactionsViewModel(Wallet wallet, Action goToAddTransaction)
        {
            _wallet = wallet;
            AddTransactionCommand = new DelegateCommand(goToAddTransaction);
            DeleteTransactionCommand = new DelegateCommand(DeleteTransaction);
            UpdateWalletTransactions();
        }
    }
}
