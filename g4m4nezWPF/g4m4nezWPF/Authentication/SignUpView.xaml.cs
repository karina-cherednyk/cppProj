using System.Windows;
using System.Windows.Controls;

namespace g4m4nez.GUI.WPF.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {

        public SignUpView()
        {
            InitializeComponent();
        }

        private void TbPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((SignUpViewModel)DataContext).Password = TbPassword.Password;
        }
    }
}
