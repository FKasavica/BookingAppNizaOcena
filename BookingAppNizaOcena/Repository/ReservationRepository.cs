using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Applications.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppNizaOcena.Repository
{
    public class ReservationRepository
    {
        private const string filePath = "../../../Resources/Data/reservations.csv";
        private readonly Serializer<Reservation> _serializer;
        private List<Reservation> _reservations;

        public ReservationRepository()
        {
            _serializer = new Serializer<Reservation>();
            _reservations = _serializer.FromCSV(filePath) ?? new List<Reservation>(); // Osiguraj da lista nije null
        }

        public Reservation? Save(Reservation reservation) // Obeleži kao nullable tip
        {
            var existingReservation = _reservations.FirstOrDefault(r => r.Id == reservation.Id);

            if (existingReservation != null)
            {
                _reservations.Remove(existingReservation);
            }

            _reservations.Add(reservation);
            _serializer.ToCSV(filePath, _reservations);
            return reservation;
        }

        public Reservation? GetById(string id) // Obeleži kao nullable tip
        {
            return _reservations.FirstOrDefault(r => r.Id == id);
        }

        public List<Reservation> GetAll()
        {
            return _reservations;
        }

        public List<Reservation> GetReservationsByGuest(string guestEmail)
        {
            return _reservations.Where(r => r.GuestEmail == guestEmail).ToList();
        }

        public List<Reservation> GetReservationsByStatus(string guestEmail, ReservationStatus status)
        {
            return _reservations.Where(r => r.GuestEmail == guestEmail && r.Status == status).ToList();
        }

        public List<Reservation> GetReservationsByApartment(string apartmentName)
        {
            return _reservations.Where(r => r.ApartmentName == apartmentName).ToList();
        }

        public void CancelReservation(Reservation reservation)
        {
            var existingReservation = _reservations.FirstOrDefault(r => r.Id == reservation.Id);
            if (existingReservation != null)
            {
                existingReservation.Status = ReservationStatus.Canceled;
                _serializer.ToCSV(filePath, _reservations);
            }
        }
    }
}
