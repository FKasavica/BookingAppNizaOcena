using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Applications.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppNizaOcena.Repository
{
    public class HotelRepository
    {
        private const string filePath = "../../../Resources/Data/hotels.csv";
        private readonly Serializer<Hotel> _serializer;
        private List<Hotel> _hotels;

        public HotelRepository()
        {
            _serializer = new Serializer<Hotel>();
            _hotels = _serializer.FromCSV(filePath) ?? new List<Hotel>(); // Osiguraj da lista nije null
        }

        public Hotel Save(Hotel hotel)
        {
            var existingHotel = _hotels.FirstOrDefault(h => h.Code == hotel.Code);

            if (existingHotel != null)
            {
                throw new Exception("A hotel with the same code already exists.");
            }

            _hotels.Add(hotel);
            _serializer.ToCSV(filePath, _hotels);
            return hotel;
        }

        public Hotel? GetByCode(string code) // Obeleži kao nullable tip
        {
            return _hotels.FirstOrDefault(h => h.Code == code);
        }

        public List<Hotel> GetAll()
        {
            return _hotels;
        }
    }
}
