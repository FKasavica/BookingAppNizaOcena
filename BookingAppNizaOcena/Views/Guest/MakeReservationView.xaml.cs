using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System;
using System.Windows;

namespace BookingAppNizaOcena.Views.Guest
{
    public partial class MakeReservationView : Window
    {
        private readonly ReservationService _reservationService;
        private readonly ApartmentService _apartmentService;
        private string _guestEmail;

        public MakeReservationView(string guestEmail)
        {
            InitializeComponent();
            _guestEmail = guestEmail;
            _reservationService = new ReservationService(new ReservationRepository());
            _apartmentService = new ApartmentService(new ApartmentRepository());

            ApartmentComboBox.ItemsSource = _apartmentService.GetAllApartments();
            ApartmentComboBox.DisplayMemberPath = "Name"; // Prikaz imena apartmana
        }

        private void SubmitReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedApartment = ApartmentComboBox.SelectedItem as Apartment;
            var selectedDate = ReservationDatePicker.SelectedDate;

            if (selectedApartment == null || selectedDate == null)
            {
                MessageBox.Show("Please select an apartment and a date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isAvailable = _reservationService.IsApartmentAvailable(selectedApartment.Name, selectedDate.Value);

            if (isAvailable)
            {
                var reservation = new Reservation
                {
                    GuestEmail = _guestEmail,
                    ApartmentName = selectedApartment.Name,
                    ReservationDate = selectedDate.Value.ToString("yyyy-MM-dd"),
                    Status = ReservationStatus.Pending
                };

                _reservationService.CreateReservation(reservation);
                MessageBox.Show("Reservation submitted! Waiting for confirmation.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Apartment is already booked for the selected date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
