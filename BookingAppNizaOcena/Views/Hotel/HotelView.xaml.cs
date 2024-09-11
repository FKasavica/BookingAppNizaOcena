using BookingAppNizaOcena.Controllers;
using BookingAppNizaOcena.Repository;
using BookingAppNizaOcena.Applications.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookingAppNizaOcena.Views
{
    public partial class HotelView : Window
    {
        private readonly HotelController _hotelController;
        private string logicalOperator = "&";  // Podrazumevani logički operator

        public HotelView()
        {
            InitializeComponent();
            _hotelController = new HotelController(new HotelService(new HotelRepository()));
            LoadHotels();  // Učitavanje hotela pri pokretanju
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = ((ComboBoxItem?)SearchByComboBox.SelectedItem)?.Tag?.ToString() ?? string.Empty; // Koristi ?? da osiguraš da string nije null
            string sortBy = ((ComboBoxItem?)SortByComboBox.SelectedItem)?.Tag?.ToString() ?? string.Empty; // I ovde koristi ?? umesto null vrednosti

            int.TryParse(RoomCountTextBox.Text, out int roomCount);
            int.TryParse(MaxGuestsTextBox.Text, out int maxGuests);

            var hotels = _hotelController.SearchHotels(searchTerm, sortBy, roomCount, maxGuests, logicalOperator); // Prosledi searchBy umesto drugog searchTerm

            // Sortiranje
            if (sortBy == "name")
            {
                hotels = hotels.OrderBy(h => h.Name).ToList();
            }
            else if (sortBy == "starRating")
            {
                hotels = hotels.OrderByDescending(h => h.StarRating).ToList();
            }

            HotelListBox.ItemsSource = hotels.Select(h => $"{h.Name} - {h.StarRating} zvezdica").ToList();
        }

        private void AndOperatorButton_Click(object sender, RoutedEventArgs e)
        {
            logicalOperator = "&";
        }

        private void OrOperatorButton_Click(object sender, RoutedEventArgs e)
        {
            logicalOperator = "|";
        }

        private void LoadHotels()
        {
            var hotels = _hotelController.GetAllHotels();
            HotelListBox.ItemsSource = hotels.Select(h => $"{h.Name} - {h.StarRating} zvezdica").ToList();
        }
    }
}
