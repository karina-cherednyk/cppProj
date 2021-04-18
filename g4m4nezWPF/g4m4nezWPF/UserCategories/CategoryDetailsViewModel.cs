using g4m4nez.BusinessLayer;
using g4m4nez.Models;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace g4m4nez.GUI.WPF.Wallets
{
    public class CategoryDetailsViewModel: BindableBase
    {
        private Category _category;
        public Category Category { get { return _category; } }
        private CategoryService  _service = new();
        public DelegateCommand SaveCommand { get;  }

        public CategoryDetailsViewModel(Category c)
        {
            _category = c;
            SaveCommand = new(() => Save());
        }
        private async void Save()
        {
            await _service.SaveCategory(CurrentSession.User.Guid, Category);
            MessageBox.Show("Category added/updated");
        }
        public string DisplayName => Category.Name;
        public string Name
        {
            get { return Category.Name; }
            set { _category.Name = value; RaisePropertyChanged(); 
                RaisePropertyChanged(nameof(DisplayName));  }
        }
        public string Description
        {
            get { return Category.Description; }
            set { _category.Description = value; RaisePropertyChanged(); }
        }
    }
}
