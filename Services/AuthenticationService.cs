using g4m4nez.BusinessLayer;
using g4m4nez.DataAccessLayer;
using g4m4nez.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace g4m4nez.Services
{
    public class AuthenticationService
    {
        private readonly FileDataStorage<DBUser> _storage = new FileDataStorage<DBUser>();

        public async Task<User> Authenticate(AuthenticationUser authUser)
        {
            Thread.Sleep(2000);
            if (string.IsNullOrWhiteSpace(authUser.Login) || string.IsNullOrWhiteSpace(authUser.Password))
            {
                throw new ArgumentException("Blank login/password");
            }

            System.Collections.Generic.List<DBUser> dbUsers = await _storage.GetAllAsync();

            DBUser dbUser = dbUsers.FirstOrDefault(user => user.Login == authUser.Login && user.Password == Encrypt(authUser.Password));
            if (dbUser == null)
            {
                throw new Exception("Invalid login/password");
            }

            User curUser = new(dbUser);
            CurrentSession.User = curUser;
            return curUser;
        }

        public async Task<bool> RegistrateUser(RegistrationUser regUser)
        {
            Thread.Sleep(2000);

            var users = await Task.Run(() => _storage.GetAllAsync());
            var dbUser = users.FirstOrDefault(user => user.Login == regUser.Login);

            if (dbUser != null)
            {
                throw new Exception("There's already user with this login");
            }

            if (string.IsNullOrWhiteSpace(regUser.Login) || string.IsNullOrWhiteSpace(regUser.Password)
                                                         || string.IsNullOrWhiteSpace(regUser.Name.Name)
                                                         || string.IsNullOrWhiteSpace(regUser.Name.Surname)
                                                         || string.IsNullOrWhiteSpace(regUser.Email.ToString()))
            {
                throw new ArgumentException("Fill all the fields!");
            }

            if (!Regex.IsMatch(regUser.Email.ToString(), @"[a-zA-Z0-9]+@[a-z]+(\.)[a-z]+$"))
            {
                throw new ArgumentException("Invalid email");
            }

            if (regUser.Login.Length > 30 || regUser.Password.Length > 30 || regUser.Name.Surname.Length > 30 || regUser.Name.Name.Length > 30)
            {
                throw new ArgumentException("Too long login/password/name/surname");
            }

            if (regUser.Login.Length < 3 || regUser.Password.Length < 3 || regUser.Name.Surname.Length < 3 || regUser.Name.Name.Length < 3)
            {
                throw new ArgumentException("Too short login/password/name/surname");
            }

            dbUser = new DBUser(Guid.NewGuid(), regUser.Name, regUser.Email, regUser.Login, Encrypt(regUser.Password));
            await _storage.AddOrUpdateAsync(dbUser);

            return true;
        }

        private string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }
    }
}
