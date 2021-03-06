
using g4m4nez.BusinessLayer;
using g4m4nez.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using g4m4nez.Utils;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class TransactionsViewModel : BindableBase, ITab
    {
        public string TabName { get; set; } = "Transactions";

        private readonly WalletService _service = new();

        private readonly Wallet _wallet;

        private int _fromN;
        public int FromN
        {
            get => _fromN;
            set
            {
                _fromN = value;
                RaisePropertyChanged();
            }
        }

        private static ITransactionDetails _currentTransaction;

        public DelegateCommand AddTransactionCommand { get; set; }
        public DelegateCommand DeleteTransactionCommand { get; }
        public DelegateCommand ShowFromNCommand { get; }


        public ITransactionDetails CurrentTransaction
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

        private ObservableCollection<TransactionDetailsViewModel> _transactions;

        public ObservableCollection<TransactionDetailsViewModel> Transactions
        {
            get
            {
                return _transactions;
            }
            set
            {
                _transactions = value;
                RaisePropertyChanged();
            }
        }

        public void UpdateWalletTransactions()
        {
            Transactions.Clear();
            foreach (Transaction tran in _wallet.GetFromIndex(FromN, 10))
            {
                Transactions.Add(new TransactionDetailsViewModel(tran, _wallet));
            }
        }

        public void DeleteTransaction()
        {
            if (_currentTransaction is not null && CurrentTransaction.GetType() == typeof(TransactionDetailsViewModel))
            {
                var tr = (TransactionDetailsViewModel)CurrentTransaction;
                _service.RemoveTransaction(CurrentSession.User.Guid, _wallet.Guid, 
                    tr.FromTransaction);
                Transactions.Remove(tr);
                CurrentTransaction = null;

            }
               

        }

        public void ShowFromN()
        {
            Transactions.Clear();
            foreach (var transaction in _wallet.GetFromIndex(FromN))
            {
                Transactions.Add(new(transaction, _wallet));
            }
        }

        public TransactionsViewModel(Wallet wallet)
        {
            _wallet = wallet;
            Transactions = new ObservableCollection<TransactionDetailsViewModel>();
            AddTransactionCommand = new DelegateCommand(() => { CurrentTransaction = new AddTransactionViewModel(this, _wallet);});
            DeleteTransactionCommand = new DelegateCommand(DeleteTransaction);
            ShowFromNCommand = new DelegateCommand(ShowFromN);
            UpdateWalletTransactions();

            foreach (var transaction in wallet.GetFromIndex(0)) {
                Transactions.Add(new(transaction, wallet));
            }

            //TODO: CLEAR SENSITIVE DATA? UpdateWalletTransactions!!!!! 
        }
    }
}
