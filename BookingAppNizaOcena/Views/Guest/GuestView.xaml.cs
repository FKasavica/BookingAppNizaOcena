using BookingAppNizaOcena.Views.User;
using BookingAppNizaOcena.Views.Guest;
using System.Windows;

namespace BookingAppNizaOcena.Views.Guest

{
    public partial class GuestView : Window
    {
        private BookingAppNizaOcena.Domain.Models.User _guestUser; // Add the missing guest user

        public GuestView(BookingAppNizaOcena.Domain.Models.User guestUser)
        {
            InitializeComponent();
            _guestUser = guestUser; // Initialize guest user
        }

        private void MakeReservationButton_Click(object sender, RoutedEventArgs e)
        {
            var makeReservationView = new MakeReservationView(_guestUser.Email);
            makeReservationView.Show();
            this.Close();
        }

        private void ViewReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            var viewReservationsView = new ViewGuestReservationView(_guestUser.Email); // Pass guest email
            viewReservationsView.Show();
            this.Close();
        }

        private void ViewHotelsButton_Click(object sender, RoutedEventArgs e)
        {
            var hotelsView = new HotelView();
            hotelsView.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginView = new UserView();
            loginView.Show();
            this.Close();
        }
    }
}
