using g4m4nez.BusinessLayer;
using g4m4nez.GUI.WPF.Navigation;
using g4m4nez.Services;
using g4m4nez.Utils;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using g4m4nez.Models;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class WalletsViewModel : BindableBase, INavigatable<MainNavigatableTypes>
    {

        public static readonly WalletService _walletSevice = new();
        private WalletDetailsViewModel _currentWalletDetailsDetails;
        public static ObservableCollection<WalletDetailsViewModel> Wallets { get; set; }

        public WalletDetailsViewModel CurrentWalletDetails
        {
            get => _currentWalletDetailsDetails;
            set
            {
                _currentWalletDetailsDetails = value;
                try
                {
                    if (_currentWalletDetailsDetails is not null)
                        ((TransactionsViewModel)_currentWalletDetailsDetails.Tabs[2]).UpdateWalletTransactions();
                }
                catch (Exception e)
                {

                }
                RaisePropertyChanged();
            }
        }

        public WalletsViewModel(Action gotoSignIn, Action goToAddWallet)
        {
            Wallets = new ObservableCollection<WalletDetailsViewModel>();

            AddWalletCommand = new DelegateCommand(goToAddWallet);
            SignInCommand = new DelegateCommand(gotoSignIn);

            DeleteWalletCommand = new DelegateCommand(DeleteWallet);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
        }

        public static void UpdateWalletsCollection()
        {
            Wallets.Clear();
            var allSavedWallets = _walletSevice.GetWallets();
            foreach (var wallet in allSavedWallets)
                if (wallet.IsOwner(CurrentSession.User))
                    Wallets.Add(new WalletDetailsViewModel(wallet));
        }

        public DelegateCommand AddWalletCommand { get; }
        public DelegateCommand SignInCommand { get; }
        public DelegateCommand DeleteWalletCommand { get; }
        public DelegateCommand CloseCommand { get; }

        public void DeleteWallet()
        {
            if (_currentWalletDetailsDetails == null)
            {
                MessageBox.Show("Please, select the wallet by clicking on it in the list.");
                return;
            }
            _walletSevice.DeleteWallet(CurrentWalletDetails.FromWallet);
            Wallets.Remove(CurrentWalletDetails);
        }

        public MainNavigatableTypes Type => MainNavigatableTypes.Wallets;

        public void ClearSensitiveData()
        {
            CurrentWalletDetails = null;
            UpdateWalletsCollection();
        }
    }
}