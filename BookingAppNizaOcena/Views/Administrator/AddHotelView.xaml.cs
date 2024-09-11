using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System;
using System.Windows;

namespace BookingAppNizaOcena.Views.Administrator
{
    public partial class AddHotelView : Window
    {
        private readonly HotelService _hotelService;

        public AddHotelView()
        {
            InitializeComponent();
            _hotelService = new HotelService(new HotelRepository());
        }

        private void SaveHotelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validacija unetih podataka
                if (string.IsNullOrWhiteSpace(HotelCodeTextBox.Text) || string.IsNullOrWhiteSpace(HotelNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(YearBuiltTextBox.Text) || string.IsNullOrWhiteSpace(StarRatingTextBox.Text) ||
                    string.IsNullOrWhiteSpace(OwnerJMBGTextBox.Text))
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Kreiraj novi hotel
                var newHotel = new Hotel
                {
                    Code = HotelCodeTextBox.Text,
                    Name = HotelNameTextBox.Text,
                    YearBuilt = int.Parse(YearBuiltTextBox.Text),
                    StarRating = int.Parse(StarRatingTextBox.Text),
                    OwnerJMBG = OwnerJMBGTextBox.Text,
                    IsConfirmed = false, // Hotel mora biti odobren
                    RejectionReason = string.Empty // Nema razloga za odbijanje
                };

                // Sačuvaj hotel putem servisa
                _hotelService.Save(newHotel);
                MessageBox.Show("Hotel added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
