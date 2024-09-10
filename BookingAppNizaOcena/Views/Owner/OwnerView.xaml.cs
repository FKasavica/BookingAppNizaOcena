using BookingAppNizaOcena.Views.Guest;
using BookingAppNizaOcena.Views.User;
using System.Windows;

namespace BookingAppNizaOcena.Views.Owner
{
    public partial class OwnerView : Window
    {
        public OwnerView()
        {
            InitializeComponent();
        }

        private void ViewReservations_Click(object sender, RoutedEventArgs e)
        {
            // Provera da li postoji ViewReservationsView
            var viewReservations = new ViewOwnerReservationView();
            viewReservations.Show();
            this.Close();
        }

        private void ManageMyHotels_Click(object sender, RoutedEventArgs e)
        {
            var manageMyHotelsView = new ManageHotelsView();
            manageMyHotelsView.Show();
            this.Close();
        }

        private void ViewAllHotels_Click(object sender, RoutedEventArgs e)
        {
            var viewHotels = new HotelView();
            viewHotels.Show();
            this.Close();
        }

        private void AddApartment_Click(object sender, RoutedEventArgs e)
        {
            var addApartment = new AddApartmentView();
            addApartment.Show();
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
