using g4m4nez.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace g4m4nez.BusinessLayer
{
    public class WalletCategories
    {
        private readonly HashSet<Category> _allCategories;
        public HashSet<Category> AllCategories => _allCategories;

        private readonly Dictionary<Category, bool> _activeCategories;
        public Dictionary<Category, bool> ActiveCategories => _activeCategories;

        [JsonConstructor]
        public WalletCategories(HashSet<Category> allCategories, Dictionary<Category, bool> activeCategories)
        {
            _allCategories = allCategories;
            _activeCategories = activeCategories;
            _activeCategories = new();
        }

        public void AddCategory(Category category)
        {
            _allCategories.Add(category);
            _activeCategories[category] = false;
        }

        public void RemoveCategory(Category category)
        {
            _allCategories.Remove(category);
            _activeCategories.Remove(category);
        }

        public void AddUserCategories(User user)
        {
            _allCategories.UnionWith(user.Categories.Categories);
            foreach (Category category in user.Categories.Categories)
            {
                _activeCategories[category] = false;
            }
        }

        public void ActivateCategory(Category category)
        {
            //if (!AllCategories.Contains(category))
            //{
            //    throw new System.InvalidOperationException("Category doesn't belong to the class");
            //}
            //else
            //{
            //    _activeCategories[category] = true;
            //}
            _activeCategories.Add(category, true);
        }
        public void DeactivateCategory(Category category)
        {
            if (!AllCategories.Contains(category))
            {
                throw new System.InvalidOperationException("Category doesn't belong to the class");
            }
            else
            {
                _activeCategories[category] = false;
            }
        }

        public WalletCategories(User owner)
        {
            _allCategories = owner.Categories.Categories;
            _activeCategories = new Dictionary<Category, bool>();
            foreach (Category category in owner.Categories.Categories)
            {
                _activeCategories[category] = true;
            }
        }

        public WalletCategories(HashSet<Category> categories)
        {
            _allCategories = categories;
            _activeCategories = new Dictionary<Category, bool>();
            foreach (Category category in categories)
            {
                _activeCategories[category] = true;
            }
        }

        public WalletCategories()
        {
            _allCategories = new HashSet<Category>();
            _activeCategories = new Dictionary<Category, bool>();
        }
    }
}