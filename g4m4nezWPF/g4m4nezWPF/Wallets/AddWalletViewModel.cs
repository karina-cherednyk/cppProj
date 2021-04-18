using g4m4nez.BusinessLayer;
using g4m4nez.GUI.WPF.Navigation;
using g4m4nez.Models;
using g4m4nez.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class AddWalletViewModel : BindableBase, INavigatable<MainNavigatableTypes>
    {
        private readonly WalletService _walletService;

        private readonly Wallet _wallet;

        public string Name
        {
            get => _wallet.Name;
            set
            {
                _wallet.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => _wallet.Description;
            set
            {
                _wallet.Description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        public decimal StartingBalance
        {
            get => _wallet.StartingBalance; // TODO: add _wallet.Transactions.CurrentAmount.Amount; as well
            set
            {
                _wallet.StartingBalance = value;
                RaisePropertyChanged(nameof(StartingBalance));
            }
        }

        public Money.Currencies MainCurrency
        {
            get
            {
                return _wallet.Currency;
            }
            set
            {
                _wallet.Currency = value;
                RaisePropertyChanged(nameof(MainCurrency));
            }
        }


        public AddWalletViewModel(Action gotoWallets)
        {
            _wallet = new Wallet(CurrentSession.User.Guid, "New wallet", "", 0.0m, Money.Currencies.USD);

            _walletService = new WalletService();
            WalletViewCommand = new DelegateCommand(gotoWallets);
            AddWalletCommand = new DelegateCommand(AddWallet);
        }

        public DelegateCommand WalletViewCommand { get; }
        public DelegateCommand AddWalletCommand { get; }
        public async void AddWallet()
        {
            // TODO: DELETE GARBAGE CODE FROM HERE
            Wallet addWallet = await _walletService.CreateWallet(CurrentSession.User.Guid, _wallet);
            
            WalletsViewModel.Wallets.Add(new WalletDetailsViewModel(addWallet));
            MessageBox.Show($"You've successfully added wallet: {addWallet.Name}!");
        }

        public MainNavigatableTypes Type => MainNavigatableTypes.AddWallet;

        public void ClearSensitiveData()
        {
            _wallet.Name = "";
            _wallet.StartingBalance = 0.0m;
            _wallet.Description = "";
        }
    }
}
