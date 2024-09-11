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

        // Pretraga hotela po kriterijumima (već postoji)
        public List<Hotel> SearchHotels(string searchTerm, string searchBy)
        {
            var hotels = _hotelRepository.GetAll();

            return searchBy switch
            {
                "code" => hotels.Where(h => h.Code.ToLower().Contains(searchTerm.ToLower())).ToList(),
                "name" => hotels.Where(h => h.Name.ToLower().Contains(searchTerm.ToLower())).ToList(),
                "yearBuilt" => hotels.Where(h => h.YearBuilt.ToString().Contains(searchTerm)).ToList(),
                "starRating" => hotels.Where(h => h.StarRating.ToString().Contains(searchTerm)).ToList(),
                _ => hotels
            };
        }

        // Pretraga hotela po kriterijumima apartmana (već postoji)
        public List<Hotel> SearchHotelsByApartmentCriteria(List<Hotel> hotels, int roomCount, int maxGuests, string logicalOperator)
        {
            return hotels.Where(h => h.Apartments.Values.Any(a =>
                logicalOperator == "&"
                    ? a.RoomCount == roomCount && a.MaxGuests == maxGuests
                    : a.RoomCount == roomCount || a.MaxGuests == maxGuests)).ToList();
        }

        // Metoda za preuzimanje svih hotela (već postoji)
        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAll();
        }

        // NOVO: Dohvatanje hotela po vlasniku
        public List<Hotel> GetHotelsByOwner(string ownerJMBG)
        {
            return _hotelRepository.GetAll().Where(h => h.OwnerJMBG == ownerJMBG).ToList();
        }

        // NOVO: Čuvanje hotela
        public void Save(Hotel hotel)
        {
            var existingHotel = _hotelRepository.GetByCode(hotel.Code);
            if (existingHotel != null)
            {
                _hotelRepository.Save(hotel); // Čuvanje hotela kroz repository
            }
        }
    }
}
