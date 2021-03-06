using g4m4nez.BusinessLayer;
using g4m4nez.Models;
using System.Threading.Tasks;
using g4m4nez.Utils;
using Prism.Commands;
using Prism.Mvvm;
namespace g4m4nez.GUI.WPF.Wallets
{
    public class WalletInfoViewModel : BindableBase, ITab
    {
        public string TabName { get; set; } = "Info";

        private readonly Wallet _wallet;
        public Wallet FromWallet => _wallet;

        public string Name
        {
            get => _wallet.Name;
            set => _wallet.Name = value;
            // TODO: FIX PSEUDO-ASYNC HACK (DELAYED EXECUTION) 
            // RaisePropertyChanged(nameof(DisplayName));
        }
        public decimal MonthIncome => _wallet.Transactions.MonthIncome.Amount;
        public decimal MonthExpences => _wallet.Transactions.MonthExpences.Amount;

        public decimal Balance // TODO: recheck
        {
            get => _wallet.StartingBalance;
            set => _wallet.StartingBalance = value;
            // TbBalance.Text = value;
            // RaisePropertyChanged(nameof(DisplayName));
        }

        public string Description
        {
            get => _wallet.Description;
            set => _wallet.Description = value;
            // RaisePropertyChanged(nameof(DisplayName));
        }

        public Money.Currencies? MainCurrency => _wallet.Currency;

        public string DisplayName => $"{_wallet.Name} ({_wallet.StartingBalance} {_wallet.Currency})";

        public WalletInfoViewModel(Wallet wallet)
        {
            _wallet = wallet;
            SubmitChangesCommand = new DelegateCommand(SubmitChanges);
        }

        public DelegateCommand SubmitChangesCommand { get; }
        public async void SubmitChanges()
        {
            await WalletsViewModel._walletSevice.AddOrUpdateWalletAsync(_wallet);
            RaisePropertyChanged(nameof(DisplayName));
            return;
        }
    }
}
