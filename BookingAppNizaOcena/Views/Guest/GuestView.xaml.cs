using BookingAppNizaOcena.Views.User;
using BookingAppNizaOcena.Views.Guest;
using System.Windows;

namespace BookingAppNizaOcena.Views
{
    public partial class GuestView : Window
    {
        public GuestView()
        {
            InitializeComponent();
        }

        private void MakeReservationButton_Click(object sender, RoutedEventArgs e)
        {
            var makeReservationView = new MakeReservationView();
            makeReservationView.Show();
            this.Close(); // Close the current window
        }

        private void ViewReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            var viewReservationsView = new ViewReservationView();
            viewReservationsView.Show();
            this.Close(); // Close the current window
        }

        private void CancelReservationButton_Click(object sender, RoutedEventArgs e)
        {
            var cancelReservationView = new CancelReservationView();
            cancelReservationView.Show();
            this.Close(); // Close the current window
        }

        private void ViewHotelsButton_Click(object sender, RoutedEventArgs e)
        {
            var hotelsView = new HotelView();
            hotelsView.Show();
            this.Close(); // Close the current window
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginView = new UserView();
            loginView.Show();
            this.Close(); // Close the current window
        }
    }
}
