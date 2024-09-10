using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using System.Collections.Generic;

namespace BookingAppNizaOcena.Controllers
{
    public class ApartmentController
    {
        private readonly ApartmentService _apartmentService;

        public ApartmentController(ApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        public Apartment AddApartment(string name, string description, int roomCount, int maxGuests)
        {
            var newApartment = new Apartment
            {
                Name = name,
                Description = description,
                RoomCount = roomCount,
                MaxGuests = maxGuests
            };

            return _apartmentService.AddApartment(newApartment);
        }

        public Apartment GetApartmentByName(string name)
        {
            return _apartmentService.GetApartmentByName(name);
        }

        public List<Apartment> GetAllApartments()
        {
            return _apartmentService.GetAllApartments();
        }
    }
}
