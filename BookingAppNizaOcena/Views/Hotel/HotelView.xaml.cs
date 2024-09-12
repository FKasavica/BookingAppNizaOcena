using BookingAppNizaOcena.Controllers;
using BookingAppNizaOcena.Repository;
using BookingAppNizaOcena.Applications.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BookingAppNizaOcena.Views.User;

namespace BookingAppNizaOcena.Views.Hotel
{
    public partial class HotelView : Window
    {
        private readonly HotelController _hotelController;
        private string logicalOperator = "&";  // Podrazumevani logički operator

        public HotelView()
        {
            InitializeComponent();
            _hotelController = new HotelController();
            LoadHotels();  // Učitavanje hotela pri pokretanju
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = ((ComboBoxItem?)SearchByComboBox.SelectedItem)?.Tag?.ToString() ?? string.Empty;
            string sortBy = ((ComboBoxItem?)SortByComboBox.SelectedItem)?.Tag?.ToString() ?? string.Empty;
            int.TryParse(RoomCountTextBox.Text, out int roomCount);
            int.TryParse(MaxGuestsTextBox.Text, out int maxGuests);

            var hotels = _hotelController.SearchAndSortHotels(searchTerm, searchTerm, roomCount, maxGuests, logicalOperator, sortBy);

            HotelListBox.ItemsSource = hotels;
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            string sortBy = ((ComboBoxItem?)SortByComboBox.SelectedItem)?.Tag?.ToString() ?? string.Empty;

            var hotels = _hotelController.GetAllHotels();

            if (sortBy == "name")
            {
                hotels = hotels.OrderBy(h => h.Split('-')[0].Trim()).ToList(); // Sortiranje po imenu
            }
            else if (sortBy == "starRating")
            {
                hotels = hotels.OrderByDescending(h => int.Parse(h.Split('-')[1].Trim().Split(' ')[0])).ToList(); // Sortiranje po broju zvezdica
            }

            HotelListBox.ItemsSource = hotels;
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
            HotelListBox.ItemsSource = hotels;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var userView = new UserView();
            userView.Show();
            this.Close();
        }
    }
}
