using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingAppNizaOcena.Views.Administrator
{
    public partial class ViewUsersView : Window
    {
        private readonly UserService _userService;
        private List<BookingAppNizaOcena.Domain.Models.User> _allUsers;

        public ViewUsersView()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository());
            LoadUsers();
        }

        private void LoadUsers()
        {
            _allUsers = _userService.GetAllUsers();
            UsersDataGrid.ItemsSource = _allUsers;
        }

        private void FilterUsersButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedType = (UserTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedType == "All")
            {
                UsersDataGrid.ItemsSource = _allUsers;
            }
            else
            {
                UsersDataGrid.ItemsSource = _allUsers.Where(u => u.UserType.ToString() == selectedType).ToList();
            }
        }

        private void BlockUnblockButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersDataGrid.SelectedItem as BookingAppNizaOcena.Domain.Models.User;
            if (selectedUser != null)
            {
                selectedUser.IsBlocked = !selectedUser.IsBlocked; // Switch block/unblock status
                _userService.Register(selectedUser); // Save updated status
                LoadUsers(); // Reload the user list
                MessageBox.Show($"{selectedUser.FirstName} {selectedUser.LastName} is now {(selectedUser.IsBlocked ? "blocked" : "unblocked")}.");
            }
            else
            {
                MessageBox.Show("Please select a user.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var adminView = new AdministratorView();
            adminView.Show();
            this.Close();
        }
    }
}
