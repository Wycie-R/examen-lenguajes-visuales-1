using System.Windows;
using System.Windows.Controls;
using ExamenApp.ViewModels;

namespace ExamenApp.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var viewModel = (LoginViewModel)DataContext;
            viewModel.Password = ((PasswordBox)sender).Password;
        }
    }
}