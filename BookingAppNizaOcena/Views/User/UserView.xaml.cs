using BookingAppNizaOcena.Controllers;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using BookingAppNizaOcena.Applications.Services;
using System.Windows;
using BookingAppNizaOcena.Views.User;
using BookingAppNizaOcena.Views.Owner;
using System.Windows.Controls;
using BookingAppNizaOcena.Views.Guest;

namespace BookingAppNizaOcena.Views.User
{
    public partial class UserView : Window
    {
        private readonly UserController _userController;
        private int loginAttempts = 0;

        public UserView()
        {
            InitializeComponent();
            _userController = new UserController(new UserService(new UserRepository()));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            var user = _userController.Login(email, password);
            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.FirstName} {user.LastName}!");

                loginAttempts = 0; // Reset login attempts after successful login

                switch (user?.UserType) // Koristi null-conditional operator kako bi osigurao da user nije null
                {
                    case UserType.Administrator:
                        var adminView = new AdministratorView();
                        adminView.Show();
                        break;
                    case UserType.Guest:
                        var guestView = new GuestView(user); // Prosledi user objekat, koji sadrži JMBG
                        guestView.Show();
                        break;
                    case UserType.Owner:
                        var ownerJMBG = user.JMBG ?? string.Empty; // Osiguraj da JMBG nije null                                                                   
                        var ownerView = new OwnerView(ownerJMBG ?? "", null, null); // Primer: dodaj provere za null i obezbedi default vrednosti
                        ownerView.Show();
                        break;
                }

                this.Close(); // Close the current window
            }
            else
            {
                loginAttempts++; // Increment failed login attempts

                if (loginAttempts >= 3)
                {
                    MessageBox.Show("Three failed login attempts. The application will close.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown(); // Close the application
                }
                else
                {
                    MessageBox.Show("Incorrect email or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var registrationView = new RegistrationView();
            registrationView.Show(); // Show the registration view
            this.Close(); // Close the current window
        }
    }
}
