using g4m4nez.BusinessLayer;
using g4m4nez.GUI.WPF.Navigation;
using g4m4nez.GUI.WPF.Wallets;
using g4m4nez.Models;
using g4m4nez.Services;
using Prism.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace g4m4nez.GUI.WPF.Authentication
{
    public class SignInViewModel : INotifyPropertyChanged, INavigatable<AuthNavigatableTypes>
    {
        private readonly AuthenticationUser _authUser = new();
        private readonly Action _gotoWalletsView;
        private bool _isEnabled = true;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public string Login
        {
            get => _authUser.Login;
            set
            {
                if (_authUser.Login != value)
                {
                    _authUser.Login = value;
                    OnPropertyChanged(nameof(Login));
                    SignInCommand.RaiseCanExecuteChanged();
                }

            }
        }

        public string Password
        {
            get => _authUser.Password;
            set
            {
                if (_authUser.Password != value)
                {
                    _authUser.Password = value;
                    OnPropertyChanged(nameof(Password));
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand SignInCommand { get; }
        public DelegateCommand CloseCommand { get; }
        public DelegateCommand SignUpCommand { get; }


        public SignInViewModel(Action gotoSignUp, Action gotoWalletsView)
        {
            SignInCommand = new DelegateCommand(SignIn, IsSignInEnabled);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
            SignUpCommand = new DelegateCommand(gotoSignUp);
            _gotoWalletsView = gotoWalletsView;

        }

        private bool IsSignInEnabled()
        {

            return !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);
        }

        private async void SignIn()
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Blank login/password");
            }
            else
            {

                AuthenticationService authService = new();
                User user = null;
                try
                {
                    IsEnabled = false;
                    user = await Task.Run(() => authService.Authenticate(_authUser));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sign in failed, error: {ex.Message}.");
                    return;
                }
                finally
                {
                    IsEnabled = true;
                }
                MessageBox.Show($"Hello, {user.Name.Name}!");
                _gotoWalletsView.Invoke();
                WalletsViewModel.UpdateWalletsCollection();
            }
        }

        public AuthNavigatableTypes Type => AuthNavigatableTypes.SignIn;
        public void ClearSensitiveData()
        {
            Password = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
