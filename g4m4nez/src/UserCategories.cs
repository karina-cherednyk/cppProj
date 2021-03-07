using System.Collections.Generic;
namespace BusinessLayer
{
    public class UserCategories
    {
        private HashSet<Category> categories;
        public HashSet<Category> Categories
        {
            get { return categories; }
        }

        public UserCategories() { }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            Categories.Remove(category);
        }
    }
}