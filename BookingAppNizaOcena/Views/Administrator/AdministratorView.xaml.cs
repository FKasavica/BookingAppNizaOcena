using BookingAppNizaOcena.Views.User;
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

        private void BlockUserButton_Click(object sender, RoutedEventArgs e)
        {
            var blockUserView = new BlockUserView();
            blockUserView.Show();
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

        private void SearchHotelsButton_Click(object sender, RoutedEventArgs e)
        {
            var searchHotelsView = new SearchHotelsView();
            searchHotelsView.Show();
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
