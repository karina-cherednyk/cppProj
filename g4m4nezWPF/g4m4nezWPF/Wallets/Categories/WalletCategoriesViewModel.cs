using g4m4nez.BusinessLayer;
using g4m4nez.Models;
using g4m4nez.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using g4m4nez.Utils;
using Prism.Mvvm;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class WalletCategoriesViewModel : BindableBase, ITab
    {
        public string TabName { get; set; } = "Categories";

        private readonly WalletService _service;
        private readonly Wallet _wallet;
        private Category _currentCategory;
        private Category _selectedCategory; // from ComboBox, for example

        public Wallet FromWallet => _wallet;

        public Category CurrentCategory
        {
            get => _currentCategory;
            set
            {
                _currentCategory = value;
                RaisePropertyChanged();
            }
        }

        public static ObservableCollection<Category> WalletCategoriesAdded { get; set; }
        public static ObservableCollection<Category> WalletCategoriesAvailable { get; set; }

        public WalletCategoriesViewModel(Wallet wallet)
        {
            _wallet = wallet;
        }

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
