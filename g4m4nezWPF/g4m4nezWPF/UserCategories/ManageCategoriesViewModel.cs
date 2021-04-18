using g4m4nez.BusinessLayer;
using g4m4nez.GUI.WPF.Navigation;
using g4m4nez.Models;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class ManageCategoriesViewModel: BindableBase, INavigatable<MainNavigatableTypes>
    {
        private CategoryService _service = new();
        public DelegateCommand GoToWalletsCommand { get;  }
        public DelegateCommand AddCategoryCommand { get; }
        public DelegateCommand DeleteCategoryCommand { get; }
        public ManageCategoriesViewModel(Action goToWallets)
        {
            GoToWalletsCommand = new DelegateCommand(() => goToWallets());
            AddCategoryCommand = new DelegateCommand(() => AddCategory());
            DeleteCategoryCommand = new DelegateCommand(() => DeleteCategory());
            Categories = new();
            CurrentSession.User.Categories.Categories.ToList()
                .ForEach(c => Categories.Add(new CategoryDetailsViewModel(c)));
        }

        private async void DeleteCategory()
        {
            if (CurrentCategoryDetails != null)
            {
                try
                {
                    await _service.RemoveCategory(CurrentSession.User.Guid, CurrentCategoryDetails.Category);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Can`t delete not saved category");
                }

                Categories.Remove(CurrentCategoryDetails);
                RaisePropertyChanged(nameof(CurrentCategoryDetails));
            }
        }
        private CategoryDetailsViewModel _currentModel;
        public CategoryDetailsViewModel CurrentCategoryDetails
        {
            get => _currentModel;
            set { _currentModel = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<CategoryDetailsViewModel> Categories { get;  }
        private void AddCategory() => 
            Categories.Add(new CategoryDetailsViewModel(new Category("New Category", "", Category.Colors.BLACK)));

        public MainNavigatableTypes Type => MainNavigatableTypes.ManageCategories;

        public void ClearSensitiveData()
        {
            
        }
    }
}
