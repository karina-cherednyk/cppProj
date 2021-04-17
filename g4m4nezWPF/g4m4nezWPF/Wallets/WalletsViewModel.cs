﻿using g4m4nez.BusinessLayer;
using g4m4nez.GUI.WPF.Navigation;
using g4m4nez.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class WalletsViewModel : BindableBase, INavigatable<MainNavigatableTypes>
    {
        public static readonly WalletService WalletSevice = new();
        private WalletDetailsViewModel _currentWallet;
        public static ObservableCollection<WalletDetailsViewModel> Wallets { get; set; }

        public WalletDetailsViewModel CurrentWallet
        {
            get => _currentWallet;
            set
            {
                _currentWallet = value;
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
            var allSavedWallets = WalletSevice.GetWallets();
            foreach (var wallet in allSavedWallets)
                if (wallet.IsOwner(CurrentSession.User))
                    Wallets.Add(new WalletDetailsViewModel(wallet));
        }

        public DelegateCommand AddWalletCommand { get; }
        public DelegateCommand SignInCommand { get; }
        public DelegateCommand DeleteWalletCommand { get; }
        public DelegateCommand CloseCommand { get; }

        public async void EditWallet()
        {
            await WalletSevice.AddOrUpdateWalletAsync(CurrentWallet.FromWallet);
        }

        public void DeleteWallet()
        {
            try
            {
                WalletSevice.DeleteWallet(CurrentWallet.FromWallet);
                Wallets.Remove(CurrentWallet);
            }
            catch (Exception)
            {
                MessageBox.Show("Please, select the wallet by clicking on it in the list.");
                return;
            }
        }

        public MainNavigatableTypes Type => MainNavigatableTypes.Wallets;

        public void ClearSensitiveData()
        {
            CurrentWallet = null;
            UpdateWalletsCollection();
        }
    }
}