using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppNizaOcena.Controllers
{
    public class HotelController
    {
        private readonly HotelService _hotelService;

        public HotelController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public List<Hotel> SearchHotels(string searchTerm, string searchBy, int roomCount, int maxGuests, string logicalOperator)
        {
            var hotels = _hotelService.SearchHotels(searchTerm, searchBy);

            // Logička pretraga po apartmanima
            if (roomCount > 0 || maxGuests > 0)
            {
                hotels = _hotelService.SearchHotelsByApartmentCriteria(hotels, roomCount, maxGuests, logicalOperator);
            }

            return hotels;
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelService.GetAllHotels();
        }
    }
}
