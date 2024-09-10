using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System.Collections.Generic;

namespace BookingAppNizaOcena.Applications.Services
{
    public class ApartmentService
    {
        private readonly ApartmentRepository _apartmentRepository;

        public ApartmentService(ApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public Apartment AddApartment(Apartment newApartment)
        {
            return _apartmentRepository.Save(newApartment);
        }

        public Apartment GetApartmentByName(string name)
        {
            return _apartmentRepository.GetByName(name);
        }

        public List<Apartment> GetAllApartments()
        {
            return _apartmentRepository.GetAll();
        }
    }
}
