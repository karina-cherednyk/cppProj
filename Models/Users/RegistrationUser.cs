namespace g4m4nez.Models
{
    public class RegistrationUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public PersonName Name { get; set; }
        public Email Email { get; set; }
    }
}