using System.Collections.Generic;

public class User
{
    private Name name
    {
        //get { return name.name + " " + name.surname; }
        set { name = value; }
    }
    private Email email;
    private HashSet<Category> categories;
}
