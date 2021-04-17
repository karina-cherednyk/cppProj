using System.Windows.Controls;

namespace g4m4nez.GUI.WPF
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainWindowContentView : UserControl
    {
        public MainWindowContentView()
        {
            InitializeComponent();
            DataContext = new MainWindowContentViewModel();
        }



    }
}
