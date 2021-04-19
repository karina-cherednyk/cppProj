using g4m4nez.BusinessLayer;
using g4m4nez.GUI.WPF.Wallets;
using g4m4nez.Models;
using g4m4nez.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace g4m4nez.GUI.WPF.Wallets
{
    class AddTransactionViewModel : BindableBase, ITransactionDetails
    {
        private readonly WalletService _service;

        private Transaction _transaction;

        private Wallet _currentWallet;

        private TransactionsViewModel _transactionsViewModel;
        public decimal Amount
        {
            get => _transaction.Amount.Amount;
            set
            {
                _transaction.Amount.Amount = value;
                RaisePropertyChanged();
            }
        }

        public string Description
        {
            get => _transaction.Description;
            set
            {
                _transaction.Description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        public Money.Currencies Currency
        {
            get => _transaction.Currency;
            set
            {
                _transaction.Currency = value;
                RaisePropertyChanged(nameof(Currency));
            }
        }

        public Category TransactionCategory
        {
            get => _transaction.TransactionCategory;
            set
            {
                _transaction.TransactionCategory = value;
                RaisePropertyChanged(nameof(TransactionCategory));
            }
        }
        public List<Category> Categories
        {
            get
            {
                return
                    _currentWallet.Categories.ActiveCategories.ToList();
            }
        }

        public DateTime Date
        {
            get => _transaction.Date;
            set
            {
                _transaction.Date = value;
                RaisePropertyChanged(nameof(Date));
            }
        }
        public DelegateCommand TransactionViewCommand { get; }
        public DelegateCommand AddTransactionCommand { get; }

        public AddTransactionViewModel(TransactionsViewModel transactionsViewModel, Wallet wallet)
        {
            _transactionsViewModel = transactionsViewModel;
            _transaction = new Transaction(
                CurrentSession.User.Guid, new Money(0, Money.Currencies.USD), "", 
                new Category("", "", "", Category.Colors.BLUE), DateTime.Now);

            _currentWallet = wallet;

            _service = new WalletService();
            //TransactionViewCommand = new DelegateCommand(gotoTransactions);
            AddTransactionCommand = new DelegateCommand(AddTransaction);
        }

        public async void AddTransaction()
        {
            try
            {
                Transaction transaction = await _service.CreateTransaction(CurrentSession.User.Guid, _currentWallet.Guid,
                    new Money(Amount, Currency), Description, TransactionCategory, Date);
                _transactionsViewModel.Transactions.Add(new TransactionDetailsViewModel(transaction, _currentWallet));
                MessageBox.Show($"You've successfully added transaction: {Amount}{Currency}!");

                _transaction = new Transaction(
                  CurrentSession.User.Guid, new Money(0, Money.Currencies.USD), "",
                  new Category("", "", "", Category.Colors.BLUE), DateTime.Now);
                RaisePropertyChanged(nameof(Amount));
                RaisePropertyChanged(nameof(Description));
                RaisePropertyChanged(nameof(Currency));
                RaisePropertyChanged(nameof(TransactionCategory));
                RaisePropertyChanged(nameof(Date));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
