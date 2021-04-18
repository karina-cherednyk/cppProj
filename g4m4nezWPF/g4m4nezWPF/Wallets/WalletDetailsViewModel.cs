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
                new WalletInfoViewModel(new Wallet(Guid.NewGuid(), "name", "", 25m, Money.Currencies.EUR)),
                new WalletCategoriesViewModel(new Wallet(Guid.NewGuid(), "name", "", 25m, Money.Currencies.EUR)),
                new TransactionsViewModel(new Wallet(Guid.NewGuid(), "name", "", 25m, Money.Currencies.EUR), new Action(doNothing))
            };
        }

    }
}
