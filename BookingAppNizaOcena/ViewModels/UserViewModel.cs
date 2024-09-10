using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Utilities;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace BookingAppNizaOcena.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        public ObservableCollection<User> Users { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public UserViewModel(UserService userService)
        {
            _userService = userService;
            Users = new ObservableCollection<User>(_userService.GetAllUsers());

            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
        }

        private void Login()
        {
            var user = _userService.Login(Email, Password);
            if (user != null)
            {
                ErrorMessage = string.Empty;
            }
            else
            {
                ErrorMessage = "Invalid email or password!";
            }
            OnPropertyChanged(nameof(ErrorMessage));
        }

        private void Register()
        {
            var existingUser = _userService.GetAllUsers().FirstOrDefault(u => u.Email == Email);
            if (existingUser != null)
            {
                ErrorMessage = "User with this email already exists!";
            }
            else
            {
                var newUser = new User
                {
                    Email = Email,
                    Password = Password,
                };
                _userService.Register(newUser);
                Users.Add(newUser);
                ErrorMessage = "Registration successful!";
            }
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
}
