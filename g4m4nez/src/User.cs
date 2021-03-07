using System.Collections.Generic;

public class User
{
    private PersonName name;
    public PersonName Name
    {
        get { return name; }
        set { name = value; }
    }

    
    private Email email;
    public Email Email
    {
        get { return email; }
        set { email = value; }
    }

    private UserCategories categories;
    public UserCategories Categories
    {
        get { return categories; }
    }
}
