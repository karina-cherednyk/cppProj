using g4m4nez.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace g4m4nez.BusinessLayer
{
    public class WalletCategories
    {
        private readonly HashSet<Category> _allCategories;
        public HashSet<Category> AllCategories => _allCategories;

        private readonly Dictionary<Category, bool> _activeCaterogies;
        public Dictionary<Category, bool> ActiveCategories => _activeCaterogies;

        [JsonConstructor]
        public WalletCategories(HashSet<Category> allCategories, Dictionary<Category, bool> activeCaterogies)
        {
            _allCategories = allCategories;
            _activeCaterogies = activeCaterogies;
        }

        public void AddCategory(Category category)
        {
            _allCategories.Add(category);
            _activeCaterogies[category] = false;
        }

        public void RemoveCategory(Category category)
        {
            _allCategories.Remove(category);
            _activeCaterogies.Remove(category);
        }

        public void AddUserCategories(User user)
        {
            _allCategories.UnionWith(user.Categories.Categories);
            foreach (Category category in user.Categories.Categories)
            {
                _activeCaterogies[category] = false;
            }
        }

        public void ActivateCategory(Category category)
        {
            if (!AllCategories.Contains(category))
            {
                throw new System.InvalidOperationException("Category doesn't belong to the class");
            }
            else
            {
                _activeCaterogies[category] = true;
            }
        }
        public void DeactivateCategory(Category category)
        {
            if (!AllCategories.Contains(category))
            {
                throw new System.InvalidOperationException("Category doesn't belong to the class");
            }
            else
            {
                _activeCaterogies[category] = false;
            }
        }

        public WalletCategories(User owner)
        {
            _allCategories = owner.Categories.Categories;
            foreach (Category category in owner.Categories.Categories)
            {
                _activeCaterogies[category] = true;
            }
        }

        public WalletCategories(HashSet<Category> categories)
        {
            _allCategories = categories;
            foreach (Category category in categories)
            {
                _activeCaterogies[category] = true;
            }
        }

        public WalletCategories()
        {
            _allCategories = new HashSet<Category>();
            _activeCaterogies = new Dictionary<Category, bool>();
        }
    }
}