using BookingAppNizaOcena.Controllers;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using BookingAppNizaOcena.Applications.Services;
using System.Windows;
using System.Windows.Controls;

namespace BookingAppNizaOcena.Views
{
    public partial class RegistrationView : Window
    {
        private readonly UserController _userController;

        public RegistrationView()
        {
            InitializeComponent();
            _userController = new UserController(new UserService(new UserRepository()));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string jmbg = JmbgTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string firstName = NameTextBox.Text;
            string lastName = SurnameTextBox.Text;
            string mobilePhone = MobileTextBox.Text;
            string userType = (UserTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(jmbg) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("JMBG, Email, and Password are mandatory!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            UserType parsedUserType = UserType.Guest;
            if (userType == "Administrator") parsedUserType = UserType.Administrator;
            else if (userType == "Vlasnik") parsedUserType = UserType.Owner;

            var newUser = new BookingAppNizaOcena.Domain.Models.User
            {
                JMBG = jmbg,
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                MobilePhone = mobilePhone,
                UserType = parsedUserType
            };

            var result = _userController.Register(newUser);

            if (result != null)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();

                // Navigate back to the login window
                var loginWindow = new UserView();
                loginWindow.Show();
                this.Close(); // Close the registration window
            }
            else
            {
                MessageBox.Show("A user with the given email or JMBG already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearFields()
        {
            JmbgTextBox.Clear();
            EmailTextBox.Clear();
            PasswordBox.Clear();
            NameTextBox.Clear();
            SurnameTextBox.Clear();
            MobileTextBox.Clear();
            UserTypeComboBox.SelectedIndex = -1;
        }
    }
}
