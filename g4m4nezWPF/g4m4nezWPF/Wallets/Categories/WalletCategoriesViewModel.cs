using g4m4nez.BusinessLayer;
using g4m4nez.Models;
using g4m4nez.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using g4m4nez.Utils;
using Prism.Mvvm;
using System.Linq;
using Prism.Commands;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class WalletCategoriesViewModel : BindableBase, ITab
    {
        public string TabName { get; set; } = "Categories";

        private readonly WalletService _service =  new();
        private readonly Wallet _wallet;
        private Category _currentCategory;
        private Category _selectedCategory; // from ComboBox, for example
        public DelegateCommand AddWalletCategoryCommand { get; }
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
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged();
            }
        }

        public static ObservableCollection<Category> WalletCategoriesAdded { get; set; }
        public static ObservableCollection<Category> WalletCategoriesAvailable { get; set; }

        public WalletCategoriesViewModel(Wallet wallet)
        {
            _wallet = wallet;
            var userCategories = CurrentSession.User.Categories.Categories;
            var walCategories = wallet.Categories.ActiveCategories.Where(x => x.Value).Select(x => x.Key).ToHashSet();
            WalletCategoriesAvailable = new(userCategories.Except(walCategories));

            AddWalletCategoryCommand = new DelegateCommand(() => AddWalletCategory());
        }

        public async void AddWalletCategory()
        {
            await Task.Run(() => _service.AddCategory(CurrentSession.User.Guid, _wallet.Guid, _selectedCategory));
            WalletCategoriesAvailable.Remove(_selectedCategory);
           
        }

        public async void RemoveWalletCategory()
        {
            await Task.Run(() => _service.RemoveCategory(CurrentSession.User.Guid, _wallet.Guid, _selectedCategory));
        }

    }

}
