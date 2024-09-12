using BookingAppNizaOcena.Applications.Services;
using System.Windows;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System.Linq;
using System.Windows.Controls;

namespace BookingAppNizaOcena.Views.Owner
{
    public partial class ViewOwnerReservationView : Window
    {
        private readonly ReservationService _reservationService;
        private readonly string _hotelCode;

        public ViewOwnerReservationView(string hotelCode)
        {
            InitializeComponent();
            _reservationService = new ReservationService(new ReservationRepository());
            _hotelCode = hotelCode;

            LoadReservations();
        }

        private void LoadReservations()
        {
            var reservations = _reservationService.GetReservationsByApartment(_hotelCode);
            ReservationsListBox.ItemsSource = reservations;
        }

        private void FilterReservations_Click(object sender, RoutedEventArgs e)
        {
            var filterType = (FilterComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            var reservations = _reservationService.GetReservationsByApartment(_hotelCode);

            if (filterType == "Pending")
            {
                ReservationsListBox.ItemsSource = reservations.Where(r => r.Status == ReservationStatus.Pending).ToList();
            }
            else if (filterType == "Confirmed")
            {
                ReservationsListBox.ItemsSource = reservations.Where(r => r.Status == ReservationStatus.Confirmed).ToList();
            }
            else
            {
                ReservationsListBox.ItemsSource = reservations;
            }
        }

        private void ConfirmReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = ReservationsListBox.SelectedItem as Reservation;
            if (selectedReservation != null && selectedReservation.Status == ReservationStatus.Pending)
            {
                selectedReservation.Status = ReservationStatus.Confirmed;
                _reservationService.CreateReservation(selectedReservation);
                LoadReservations();
            }
        }

        private void RejectReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = ReservationsListBox.SelectedItem as Reservation;
            if (selectedReservation != null && selectedReservation.Status == ReservationStatus.Pending)
            {
                var rejectionReason = RejectionReasonTextBox.Text;
                selectedReservation.Status = ReservationStatus.Rejected;
                selectedReservation.RejectionReason = rejectionReason;
                _reservationService.CreateReservation(selectedReservation);
                LoadReservations();
            }
        }

        private void CancelReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = ReservationsListBox.SelectedItem as Reservation;
            if (selectedReservation != null)
            {
                _reservationService.CancelReservation(selectedReservation);
                LoadReservations();
            }
        }
    }
}
