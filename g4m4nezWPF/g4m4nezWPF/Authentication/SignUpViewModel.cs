
using g4m4nez.GUI.WPF.Navigation;
using g4m4nez.Models;
using g4m4nez.Services;
using Prism.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace g4m4nez.GUI.WPF.Authentication
{
    public class SignUpViewModel : INotifyPropertyChanged, INavigatable<AuthNavigatableTypes>
    {
        private RegistrationUser _regUser = new();
        private readonly Action _gotoSignIn;
        public AuthNavigatableTypes Type => AuthNavigatableTypes.SignUp;
        public string Login
        {
            get => _regUser.Login;
            set
            {
                if (_regUser.Login != value)
                {
                    _regUser.Login = value;
                    OnPropertyChanged(nameof(Login));
                    SignUpCommand.RaiseCanExecuteChanged();
                }

            }
        }
        public string Password
        {
            get => _regUser.Password;
            set
            {
                if (_regUser.Password != value)
                {
                    _regUser.Password = value;
                    OnPropertyChanged(nameof(Password));
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string LastName
        {
            get => _regUser.Name.Surname;
            set
            {
                if (_regUser.Name.Surname != value)
                {
                    _regUser.Name = new PersonName(_regUser.Name.Name, value);
                    OnPropertyChanged(nameof(LastName));
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string FirstName
        {
            get => _regUser.Name.Name;
            set
            {
                if (_regUser.Name.Name != value)
                {
                    _regUser.Name = new PersonName(value, _regUser.Name.Surname);
                    OnPropertyChanged(nameof(FirstName));
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string Email
        {
            get => _regUser.Email.ToString();
            set
            {
                if (_regUser.Email.ToString() != value)
                {
                    _regUser.Email = new Email(value);
                    OnPropertyChanged(nameof(Email));
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public DelegateCommand SignUpCommand { get; }
        public DelegateCommand CloseCommand { get; }
        public DelegateCommand SignInCommand { get; }
        public SignUpViewModel(Action gotoSignIn)
        {
            SignUpCommand = new DelegateCommand(SignUp, IsSignUpEnabled);
            CloseCommand = new DelegateCommand(() => Environment.Exit(0));
            _gotoSignIn = gotoSignIn;
            SignInCommand = new DelegateCommand(_gotoSignIn);
        }
        private bool IsSignUpEnabled()
        {

            return !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(Email);
        }
        private async void SignUp()
        {
            AuthenticationService authService = new AuthenticationService();
            try
            {
                await authService.RegistrateUser(_regUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sign in failed, erorr: {ex.Message}");
                return;
            }
            MessageBox.Show("Successfully signed up!");
            _gotoSignIn.Invoke();
        }

        public void ClearSensitiveData()
        {
            _regUser = new RegistrationUser();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
