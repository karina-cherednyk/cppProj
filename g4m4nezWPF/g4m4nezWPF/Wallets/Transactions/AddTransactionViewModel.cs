﻿using g4m4nez.BusinessLayer;
using g4m4nez.GUI.WPF.Wallets;
using g4m4nez.Models;
using g4m4nez.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;

namespace g4m4nez.GUI.WPF.Wallets
{
    class AddTransactionViewModel : BindableBase
    {
        private readonly WalletService _service;

        private Transaction _transaction;

        private Wallet _currentWallet;

        public Money Amount
        {
            get => _transaction.Amount;
            set
            {
                _transaction.Amount = value;
                RaisePropertyChanged(nameof(Amount));
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

        public AddTransactionViewModel(Action gotoTransactions, Wallet wallet)
        {
            _transaction = new Transaction(
                CurrentSession.User.Guid, new Money(0, Money.Currencies.USD), "", 
                new Category("", "", "", Category.Colors.BLUE), DateTime.Now);

            _currentWallet = wallet;

            _service = new WalletService();
            TransactionViewCommand = new DelegateCommand(gotoTransactions);
            AddTransactionCommand = new DelegateCommand(AddTransaction);
        }

        public async void AddTransaction()
        {
            Transaction transaction = await _service.CreateTransaction(CurrentSession.User.Guid, _currentWallet.Guid,
                Amount, Description, TransactionCategory, Date);

            TransactionsViewModel.Transactions.Add(new TransactionDetailsViewModel(transaction, _currentWallet));
            MessageBox.Show($"You've successfully added transaction: {Amount}{Currency}!");
        }
    }
}
