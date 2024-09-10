using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System.Collections.Generic;
using System.Windows;

namespace BookingAppNizaOcena.Views.Guest
{
    public partial class ViewReservationsView : Window
    {
        private readonly ReservationService _reservationService;
        private BookingAppNizaOcena.Domain.Models.User _guestUser;

        public ViewReservationsView(BookingAppNizaOcena.Domain.Models.User guestUser)
        {
            InitializeComponent();
            _guestUser = guestUser;
            _reservationService = new ReservationService(new ReservationRepository());

            // Prikaz svih rezervacija gosta
            ReservationsDataGrid.ItemsSource = _reservationService.GetReservationsByGuest(_guestUser);
        }

        private void FilterReservations_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilter = ReservationStatusComboBox.SelectedItem as string;

            List<Reservation> filteredReservations = selectedFilter switch
            {
                "Pending" => _reservationService.GetPendingReservationsByGuest(_guestUser),
                "Confirmed" => _reservationService.GetConfirmedReservationsByGuest(_guestUser),
                "Rejected" => _reservationService.GetRejectedReservationsByGuest(_guestUser),
                _ => _reservationService.GetReservationsByGuest(_guestUser)
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
                ReservationsDataGrid.ItemsSource = _reservationService.GetReservationsByGuest(_guestUser);
            }
            else
            {
                MessageBox.Show("You can only cancel pending or confirmed reservations.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
