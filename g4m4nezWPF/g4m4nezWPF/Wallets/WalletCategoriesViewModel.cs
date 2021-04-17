using g4m4nez.BusinessLayer;
using g4m4nez.Models;
using g4m4nez.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace g4m4nez.GUI.WPF.Wallets
{
    class WalletCategoriesViewModel
    {
        private readonly WalletService _service;

        private readonly Wallet _wallet;
        public Wallet FromWallet => _wallet;

        private Category _selectedCategory;
        public static ObservableCollection<Category> WalletCategoriesAdded { get; set; }
        public static ObservableCollection<Category> WalletCategoriesAvailable { get; set; }

        public async void AddWalletCategory()
        {
            await Task.Run(() => _service.AddCategory(CurrentSession.User.Guid, _wallet.Guid, _selectedCategory));
        }

        public async void RemoveWalletCategory()
        {
            await Task.Run(() => _service.RemoveCategory(CurrentSession.User.Guid, _wallet.Guid, _selectedCategory));
        }

    }

}
