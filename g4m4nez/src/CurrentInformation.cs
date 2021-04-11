namespace g4m4nez.BusinessLayer
{
    public static class CurrentSession
    {
        private static User _user;
        public static User User
        {
            get => _user;
            set => _user = value;
        }
    }
}