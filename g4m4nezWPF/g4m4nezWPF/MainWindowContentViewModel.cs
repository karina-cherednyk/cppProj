using System;
using g4m4nez.BusinessLayer;
using g4m4nez.GUI.WPF.Authentication;
using g4m4nez.GUI.WPF.Navigation;
using g4m4nez.GUI.WPF.Wallets;

namespace g4m4nez.GUI.WPF
{
    public class MainWindowContentViewModel : NavigationBase<MainNavigatableTypes>
    {
        public MainWindowContentViewModel()
        {
            Navigate(MainNavigatableTypes.Auth);
        }

        protected override INavigatable<MainNavigatableTypes> CreateViewModel(MainNavigatableTypes type)
        {
            if (type == MainNavigatableTypes.Auth)
            {
                return new AuthViewModel(() =>  Navigate(MainNavigatableTypes.Wallets));
            }
            else if (type == MainNavigatableTypes.Wallets)
            {
                return new WalletsViewModel(() => Navigate(MainNavigatableTypes.Auth), () => Navigate(MainNavigatableTypes.AddWallet));
            }
            else
            {
                return new AddWalletViewModel(() => Navigate(MainNavigatableTypes.Wallets));
            }
        }
    }
}
