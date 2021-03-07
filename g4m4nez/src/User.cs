using System;
using System.Collections.Generic;
namespace Entities
{
    public class User
    {
        private Name name;
        private Email email;
        private HashSet<Category> categories;
    }
}
