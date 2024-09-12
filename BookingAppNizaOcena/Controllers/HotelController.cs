using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppNizaOcena.Controllers
{
    public class HotelController
    {
        private readonly HotelService _hotelService;

        public HotelController()
        {
            _hotelService = new HotelService(new HotelRepository());
        }

        public List<string> SearchAndSortHotels(string searchTerm, string searchBy, int roomCount, int maxGuests, string logicalOperator, string sortBy)
        {
            var hotels = _hotelService.SearchHotels(searchTerm, searchBy);

            // Napredna pretraga po sobama i gostima
            if (roomCount > 0 || maxGuests > 0)
            {
                hotels = _hotelService.SearchHotelsByApartmentCriteria(hotels, roomCount, maxGuests, logicalOperator);
            }

            // Sortiranje
            if (sortBy == "name")
            {
                hotels = hotels.OrderBy(h => h.Name).ToList();
            }
            else if (sortBy == "starRating")
            {
                hotels = hotels.OrderByDescending(h => h.StarRating).ToList();
            }

            return hotels.Select(h => $"{h.Name} - {h.StarRating} zvezdica").ToList();
        }

        public List<string> GetAllHotels()
        {
            return _hotelService.GetAllHotels().Select(h => $"{h.Name} - {h.StarRating} zvezdica").ToList();
        }
    }
}
