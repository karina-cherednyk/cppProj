using System.Collections.Generic;
namespace BusinessLayer
{
    public class BusinessLayer
    {
        private List<User> Users;
        private List<Wallet> Wallets;
        private Dictionary<User, List<Wallet>> UserToWallets = new Dictionary<User, List<Wallet>>();
        private Dictionary<Wallet, List<User>> WalletToUsers = new Dictionary<Wallet, List<User>>();

        public void CreateUser(PersonName name, Email email)
        {
            User user = new User(name, email);
            Users.Add(user);
            UserToWallets[user] = new List<Wallet>();
        }

        public void CreateWallet(User owner, string name, decimal startingBalance, Money.Currencies currency)
        {
            Wallet wallet = new Wallet(owner, name, startingBalance, currency);
            Wallets.Add(wallet);
            WalletToUsers[wallet].Add(owner);
        }
    }
}
