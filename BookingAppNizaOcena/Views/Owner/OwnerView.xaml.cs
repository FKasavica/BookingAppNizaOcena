using BookingAppNizaOcena.Views.Guest;
using BookingAppNizaOcena.Views.User;
using BookingAppNizaOcena.Views.Hotel;
using BookingAppNizaOcena.Domain.Models;
using System.Windows;

namespace BookingAppNizaOcena.Views.Owner
{
    public partial class OwnerView : Window
    {
        private string _ownerJMBG;
        private string _hotelCode; // Assuming these are set somewhere in the logic
        private BookingAppNizaOcena.Domain.Models.Hotel _hotel;

        public OwnerView(string ownerJMBG, string hotelCode, BookingAppNizaOcena.Domain.Models.Hotel hotel)
        {
            InitializeComponent();
            _ownerJMBG = ownerJMBG;
            _hotelCode = hotelCode;
            _hotel = hotel;
        }

        private void ViewReservations_Click(object sender, RoutedEventArgs e)
        {
            var viewReservations = new ViewOwnerReservationView(_hotelCode); // Pass hotelCode
            viewReservations.Show();
            this.Close();
        }

        private void ManageMyHotels_Click(object sender, RoutedEventArgs e)
        {
            var manageMyHotelsView = new ManageHotelsView(_ownerJMBG); // Pass ownerJMBG
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
            var addApartment = new AddApartmentView(_hotel); // Pass hotel
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
