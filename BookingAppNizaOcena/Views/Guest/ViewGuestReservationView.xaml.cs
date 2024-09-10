using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System.Collections.Generic;
using System.Windows;

namespace BookingAppNizaOcena.Views.Guest
{
    public partial class ViewGuestReservationView : Window
    {
        private readonly ReservationService _reservationService;
        private string _guestEmail;

        public ViewGuestReservationView(string guestEmail)
        {
            InitializeComponent();
            _guestEmail = guestEmail;
            _reservationService = new ReservationService(new ReservationRepository());

            // Prikaz svih rezervacija gosta
            ReservationsDataGrid.ItemsSource = _reservationService.GetReservationsByGuest(_guestEmail);
        }

        private void FilterReservations_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilter = ReservationStatusComboBox.SelectedItem as string;

            List<Reservation> filteredReservations = selectedFilter switch
            {
                "Pending" => _reservationService.GetPendingReservationsByGuest(_guestEmail),
                "Confirmed" => _reservationService.GetConfirmedReservationsByGuest(_guestEmail),
                "Rejected" => _reservationService.GetRejectedReservationsByGuest(_guestEmail),
                _ => _reservationService.GetReservationsByGuest(_guestEmail)
            };

            ReservationsDataGrid.ItemsSource = filteredReservations;
        }

        private void CancelReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = ReservationsDataGrid.SelectedItem as Reservation;

            if (selectedReservation == null)
            {
                MessageBox.Show("Please select a reservation to cancel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (selectedReservation.Status == ReservationStatus.Pending || selectedReservation.Status == ReservationStatus.Confirmed)
            {
                _reservationService.CancelReservation(selectedReservation);
                MessageBox.Show("Reservation canceled successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh the reservation list after cancellation
                ReservationsDataGrid.ItemsSource = _reservationService.GetReservationsByGuest(_guestEmail);
            }
            else
            {
                MessageBox.Show("You can only cancel pending or confirmed reservations.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
