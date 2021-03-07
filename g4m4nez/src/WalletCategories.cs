using System.Collections.Generic;
namespace BusinessLayer
{
    public class WalletCategories
    {
        private HashSet<Category> allCategories;
        public HashSet<Category> AllCategories
        {
            get { return allCategories; }
        }

        private Dictionary<Category, bool> activeCaterogies;
        public Dictionary<Category, bool> ActiveCategories
        {
            get { return activeCaterogies; }
        }

        public void AddCategory(Category category)
        {
            allCategories.Add(category);
            activeCaterogies[category] = false;
        }

        public void RemoveCategory(Category category)
        {
            allCategories.Remove(category);
            activeCaterogies.Remove(category);
        }

        public void AddUserCategories(User user)
        {
            allCategories.UnionWith(user.Categories.Categories);
            foreach (Category category in user.Categories.Categories)
            {
                activeCaterogies[category] = false;
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
                activeCaterogies[category] = true;
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
                activeCaterogies[category] = false;
            }
        }

        public WalletCategories(User owner)
        {
            allCategories = owner.Categories.Categories;
            foreach (Category category in owner.Categories.Categories)
            {
                activeCaterogies[category] = true;
            }
        }

        public WalletCategories(HashSet<Category> categories)
        {
            allCategories = categories;
            foreach (Category category in categories)
            {
                activeCaterogies[category] = true;
            }
        }

        public WalletCategories()
        {
            allCategories = new HashSet<Category>();
            activeCaterogies = new Dictionary<Category, bool>;
        }
    }
}