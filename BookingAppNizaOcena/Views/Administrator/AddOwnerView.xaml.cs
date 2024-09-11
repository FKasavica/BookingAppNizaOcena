using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System;
using System.Windows;

namespace BookingAppNizaOcena.Views.Administrator
{
    public partial class AddOwnerView : Window
    {
        private readonly UserService _userService;

        public AddOwnerView()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository()); // Inicijalizacija servisa
        }

        private void AddOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = FirstNameTextBox.Text;
                string lastName = LastNameTextBox.Text;
                string jmbg = JMBGTextBox.Text;
                string email = EmailTextBox.Text;

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                    string.IsNullOrWhiteSpace(jmbg) || string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newUser = new BookingAppNizaOcena.Domain.Models.User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    JMBG = jmbg,
                    Email = email,
                    UserType = UserType.Owner, // Postavi tip korisnika na Owner
                    Password = "defaultPassword" // Inicijalna lozinka, može se promeniti kasnije
                };

                _userService.Register(newUser);
                MessageBox.Show("Owner added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
