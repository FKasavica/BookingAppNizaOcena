using BookingAppNizaOcena.Applications.Services;
using System.Windows;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;

namespace BookingAppNizaOcena.Views.Owner
{
    public partial class ManageHotelsView : Window
    {
        private readonly HotelService _hotelService;
        private readonly string _ownerJMBG;

        public ManageHotelsView(string ownerJMBG)
        {
            InitializeComponent();
            _hotelService = new HotelService(new HotelRepository());
            _ownerJMBG = ownerJMBG;

            LoadHotels();
        }

        private void LoadHotels()
        {
            var hotels = _hotelService.GetHotelsByOwner(_ownerJMBG);
            HotelsListBox.ItemsSource = hotels;
        }

        private void ConfirmHotel_Click(object sender, RoutedEventArgs e)
        {
            var selectedHotel = HotelsListBox.SelectedItem as BookingAppNizaOcena.Domain.Models.Hotel;
            if (selectedHotel != null && !selectedHotel.IsConfirmed)
            {
                selectedHotel.IsConfirmed = true;
                _hotelService.Save(selectedHotel);
                LoadHotels(); // Osvetli hotele nakon potvrde
            }
        }

        private void RejectHotel_Click(object sender, RoutedEventArgs e)
        {
            var selectedHotel = HotelsListBox.SelectedItem as BookingAppNizaOcena.Domain.Models.Hotel;
            if (selectedHotel != null && !selectedHotel.IsConfirmed)
            {
                var rejectionReason = HotelRejectionReasonTextBox.Text;
                selectedHotel.RejectionReason = rejectionReason; // Dodavanje razloga za odbijanje
                _hotelService.Save(selectedHotel);
                LoadHotels(); // Osvetli hotele nakon odbijanja
            }
        }

        private void AddApartment_Click(object sender, RoutedEventArgs e)
        {
            var selectedHotel = HotelsListBox.SelectedItem as BookingAppNizaOcena.Domain.Models.Hotel;
            if (selectedHotel != null)
            {
                var addApartmentWindow = new AddApartmentView(selectedHotel); // Otvara novi prozor za dodavanje apartmana
                addApartmentWindow.ShowDialog();
                LoadHotels(); // Osvetli hotele nakon dodavanja apartmana
            }
        }
    }
}
