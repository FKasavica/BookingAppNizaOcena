using BookingAppNizaOcena.Views.User;
using BookingAppNizaOcena.Views.Hotel;
using BookingAppNizaOcena.Views.Administrator;
using System.Windows;

namespace BookingAppNizaOcena.Views
{
    public partial class AdministratorView : Window
    {
        public AdministratorView()
        {
            InitializeComponent();
        }

        private void AddOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            var addOwnerView = new AddOwnerView();
            addOwnerView.Show();
            this.Close(); // Close current window
        }

        private void ViewUsersButton_Click(object sender, RoutedEventArgs e)
        {
            var viewUsersView = new ViewUsersView();
            viewUsersView.Show();
            this.Close(); // Close current window
        }

        private void AddHotelButton_Click(object sender, RoutedEventArgs e)
        {
            var addHotelView = new AddHotelView();
            addHotelView.Show();
            this.Close(); // Close current window
        }

        private void ViewHotelsButton_Click(object sender, RoutedEventArgs e)
        {
            var viewHotelsView = new HotelView();
            viewHotelsView.Show();
            this.Close(); // Close current window
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginView = new UserView();
            loginView.Show();
            this.Close(); // Close current window
        }
    }
}
