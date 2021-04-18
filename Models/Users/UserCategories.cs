using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace g4m4nez.Models
{
    [Serializable]
    public class UserCategories
    {
        private readonly HashSet<Category> categories;
        public HashSet<Category> Categories => categories;

        public UserCategories()
        {
            categories = new HashSet<Category>();
        }

        [JsonConstructor]
        public UserCategories(HashSet<Category> categories)
        {
            this.categories = categories;
        }

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