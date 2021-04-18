using g4m4nez.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace g4m4nez.BusinessLayer
{
    public class WalletCategories
    {

        private HashSet<Category> _activeCategories;
        public HashSet<Category> ActiveCategories => _activeCategories;

        [JsonConstructor]
        public WalletCategories(HashSet<Category> activeCategories)
        {
            _activeCategories = activeCategories;
        }

        public void AddCategory(Category category)
        {
            _activeCategories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            _activeCategories.Remove(category);
        }


        public void ActivateCategory(Category category)
        {
            _activeCategories.Add(category);
        }
        public void DeactivateCategory(Category category)
        {
            _activeCategories.Remove(category);
        }

        public WalletCategories()
        {
            _activeCategories = new ();
        }
    }
}