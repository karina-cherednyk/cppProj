using g4m4nez.BusinessLayer;
using g4m4nez.DataAccessLayer;
using g4m4nez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService
    {
        private readonly FileDataStorage<DBUser> _dbUsers = new();

        public async Task SaveCategory(Guid userID, Category cat)
        {
            DBUser dbOwner = await _dbUsers.GetAsync(userID);
            dbOwner.Categories.AddCategory(cat);

            await _dbUsers.AddOrUpdateAsync(dbOwner);
            CurrentSession.User.Categories.AddCategory(cat);
        }

        public async Task RemoveCategory(Guid userID, Category cat)
        {
            DBUser dbOwner = await _dbUsers.GetAsync(userID);
            dbOwner.Categories.RemoveCategory(cat);
            await _dbUsers.AddOrUpdateAsync(dbOwner);
            CurrentSession.User.Categories.RemoveCategory(cat);
        }

    }
}
