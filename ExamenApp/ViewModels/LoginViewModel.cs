using System.Linq;
using System.Windows;
using System.Windows.Input;
using ExamenApp.Data;
using ExamenApp.Views;

namespace ExamenApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private readonly AppDbContext _context;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            _context = new AppDbContext();
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
        }

        private void Login()
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
            if (user != null)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void Register()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Username == Username);
            if (existingUser != null)
            {
                MessageBox.Show("Usuario ya existe");
                return;
            }

            var newUser = new Models.User
            {
                Username = Username,
                Password = Password,
                Email = Username + "@email.com"
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            MessageBox.Show("Usuario registrado exitosamente");
        }
    }
}