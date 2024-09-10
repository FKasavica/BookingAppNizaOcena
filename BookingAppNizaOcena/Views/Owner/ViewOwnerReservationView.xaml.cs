using BookingAppNizaOcena.Applications.Services;
using System.Windows;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;

namespace BookingAppNizaOcena.Views.Owner
{
    public partial class ViewOwnerReservationView : Window
    {
        private readonly ReservationService _reservationService;
        private readonly string _guestEmail;

        public ViewOwnerReservationView(string guestEmail)
        {
            InitializeComponent();
            _reservationService = new ReservationService(new ReservationRepository());
            _guestEmail = guestEmail; // Koristimo email kao string

            LoadReservations();
        }

        private void LoadReservations()
        {
            var reservations = _reservationService.GetReservationsByGuest(_guestEmail);
            ReservationsListBox.ItemsSource = reservations; // Prikaz rezervacija u nekoj kontrolnoj listi
        }

        private void CancelReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = ReservationsListBox.SelectedItem as Reservation;
            if (selectedReservation != null)
            {
                _reservationService.CancelReservation(selectedReservation);
                LoadReservations(); // Osvetli rezervacije nakon otkazivanja
            }
        }
    }
}
