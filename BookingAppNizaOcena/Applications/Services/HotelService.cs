using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System.Collections.Generic;

namespace BookingAppNizaOcena.Applications.Services
{
    public class HotelService
    {
        private readonly HotelRepository _hotelRepository;

        public HotelService(HotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public Hotel AddHotel(Hotel newHotel)
        {
            return _hotelRepository.Save(newHotel);
        }

        public Hotel GetHotelByCode(string code)
        {
            return _hotelRepository.GetByCode(code);
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAll();
        }
    }
}
