using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppNizaOcena.Applications.Services
{
    public class HotelService
    {
        private readonly HotelRepository _hotelRepository;

        public HotelService(HotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public List<Hotel> SearchHotels(string searchTerm, string searchBy)
        {
            var hotels = _hotelRepository.GetAll();

            // Pretraga po kriterijumu (delimičan unos i neosetljivost na mala/velika slova)
            return searchBy switch
            {
                "code" => hotels.Where(h => h.Code.ToLower().Contains(searchTerm.ToLower())).ToList(),
                "name" => hotels.Where(h => h.Name.ToLower().Contains(searchTerm.ToLower())).ToList(),
                "yearBuilt" => hotels.Where(h => h.YearBuilt.ToString().Contains(searchTerm)).ToList(),
                "starRating" => hotels.Where(h => h.StarRating.ToString().Contains(searchTerm)).ToList(),
                _ => hotels
            };
        }

        public List<Hotel> SearchHotelsByApartmentCriteria(List<Hotel> hotels, int roomCount, int maxGuests, string logicalOperator)
        {
            // Logički operator za kombinaciju soba i gostiju (& ili |)
            return hotels.Where(h => h.Apartments.Values.Any(a =>
                logicalOperator == "&"
                    ? a.RoomCount == roomCount && a.MaxGuests == maxGuests
                    : a.RoomCount == roomCount || a.MaxGuests == maxGuests)).ToList();
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAll();
        }
    }
}
