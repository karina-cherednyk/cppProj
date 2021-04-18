using System;

using System.Collections.ObjectModel;

using g4m4nez.BusinessLayer;
using g4m4nez.GUI.WPF.Navigation;
using g4m4nez.Models;
using g4m4nez.Utils;
using Prism.Mvvm;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class WalletDetailsViewModel : NavigationBase<MainNavigatableTypes>
    {
        private readonly Wallet _wallet;
        public ObservableCollection<ITab> Tabs { get; }

        public string DisplayName => $"{_wallet.Name} ({_wallet.StartingBalance} {_wallet.Currency})";

        public Wallet FromWallet => _wallet;

        public int DefaultTabIdx { get; } = 0;

        void doNothing()
        { }

        protected override INavigatable<MainNavigatableTypes> CreateViewModel(MainNavigatableTypes type)
        {
            throw new NotImplementedException();
        }

        public WalletDetailsViewModel(Wallet wallet)
        {
            _wallet = wallet;
            Tabs = new ObservableCollection<ITab>
            {
                //Tabs.Add(new WalletDetailsViewModel(_currentWalletDetailsDetails.FromWallet));
                new WalletInfoViewModel(_wallet),
                new WalletCategoriesViewModel(_wallet),
                new TransactionsViewModel(_wallet, new Action(doNothing))
            };
        }

    }
}
