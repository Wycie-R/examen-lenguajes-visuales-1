using System.Windows;
using System.Windows.Controls;
using ExamenApp.ViewModels;

namespace ExamenApp.Views
{
    public partial class LoginWindow : Window
    {
        private void bPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}