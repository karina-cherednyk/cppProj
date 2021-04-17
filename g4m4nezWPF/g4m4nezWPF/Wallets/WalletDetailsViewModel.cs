﻿using System;

using System.Collections.ObjectModel;

using g4m4nez.BusinessLayer;
using g4m4nez.Models;
using g4m4nez.Utils;
using Prism.Mvvm;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class WalletDetailsViewModel : BindableBase
    {
        private readonly Wallet _wallet;
        public ObservableCollection<ITab> Tabs { get; }

        public string DisplayName => $"{_wallet.Name} ({_wallet.StartingBalance} {_wallet.Currency})";

        public Wallet FromWallet => _wallet;

        void doNothing()
        { }


        public WalletDetailsViewModel(Wallet wallet)
        {
            _wallet = wallet;
            Tabs = new ObservableCollection<ITab>();
            //Tabs.Add(new WalletDetailsViewModel(_currentWalletDetailsDetails.FromWallet));
            Tabs.Add(new WalletInfoViewModel(new Wallet(Guid.NewGuid(), "name", "", 25m, Money.Currencies.EUR)));
            Tabs.Add(new WalletCategoriesViewModel(new Wallet(Guid.NewGuid(), "name", "", 25m, Money.Currencies.EUR)));
            Tabs.Add(new TransactionsViewModel(new Wallet(Guid.NewGuid(), "name", "", 25m, Money.Currencies.EUR), new Action(doNothing)));
        }

    }
}
