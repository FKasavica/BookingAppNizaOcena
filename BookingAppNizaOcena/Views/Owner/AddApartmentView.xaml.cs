using BookingAppNizaOcena.Applications.Services;
using System.Windows;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;

namespace BookingAppNizaOcena.Views.Owner
{
    public partial class AddApartmentView : Window
    {
        private readonly ApartmentService _apartmentService;
        private readonly Hotel _hotel;

        public AddApartmentView(Hotel hotel)
        {
            InitializeComponent();
            _apartmentService = new ApartmentService(new ApartmentRepository());
            _hotel = hotel;
        }

        private void SaveApartment_Click(object sender, RoutedEventArgs e)
        {
            var apartment = new Apartment(ApartmentNameTextBox.Text, ApartmentDescriptionTextBox.Text, int.Parse(ApartmentRoomCountTextBox.Text), int.Parse(ApartmentMaxGuestsTextBox.Text));
            _apartmentService.AddApartment(apartment); // Metoda iz ApartmentService koja koristi Repository za čuvanje
            _hotel.Apartments.Add(apartment.Name, apartment); // Dodavanje apartmana u hotel
            new HotelService(new HotelRepository()).Save(_hotel); // Čuvanje hotela sa novim apartmanom
            Close(); // Zatvara prozor nakon dodavanja apartmana
        }
    }
}
