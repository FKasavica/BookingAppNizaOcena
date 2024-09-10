using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Applications.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppNizaOcena.Repository
{
    public class ApartmentRepository
    {
        private const string filePath = "../../../Resources/Data/apartments.csv";
        private readonly Serializer<Apartment> _serializer;
        private List<Apartment> _apartments;

        public ApartmentRepository()
        {
            _serializer = new Serializer<Apartment>();
            _apartments = _serializer.FromCSV(filePath);
        }

        public Apartment Save(Apartment apartment)
        {
            _apartments.Add(apartment);
            _serializer.ToCSV(filePath, _apartments);
            return apartment;
        }

        public Apartment GetByName(string name)
        {
            return _apartments.FirstOrDefault(a => a.Name == name);
        }

        public List<Apartment> GetAll()
        {
            return _apartments;
        }
    }
}
