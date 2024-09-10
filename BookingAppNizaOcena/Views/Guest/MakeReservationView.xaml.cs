using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using BookingAppNizaOcena.Applications.Services;
using System;
using System.Windows;

namespace BookingAppNizaOcena.Views.Guest
{
    public partial class MakeReservationView : Window
    {
        private readonly ReservationService _reservationService;
        private readonly ApartmentService _apartmentService;
        private BookingAppNizaOcena.Domain.Models.User _guestUser;

        public MakeReservationView(BookingAppNizaOcena.Domain.Models.User guestUser)
        {
            InitializeComponent();
            _guestUser = guestUser; // Koristimo drugačije ime za korisnika
            _reservationService = new ReservationService(new ReservationRepository());
            _apartmentService = new ApartmentService(new ApartmentRepository());

            // Popunjavanje liste apartmana
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

            // Proveravamo da li je apartman slobodan
            bool isAvailable = _reservationService.IsApartmentAvailable(selectedApartment, selectedDate.Value);

            if (isAvailable)
            {
                // Kreiramo rezervaciju
                var reservation = new Reservation
                {
                    Apartment = selectedApartment,
                    Guest = _guestUser,
                    ReservationDate = selectedDate.Value,
                    Status = ReservationStatus.Pending // Na čekanju
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
