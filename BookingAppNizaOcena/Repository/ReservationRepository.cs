using BookingAppNizaOcena.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppNizaOcena.Repository
{
    public class ReservationRepository
    {
        private List<Reservation> _reservations;

        public ReservationRepository()
        {
            _reservations = new List<Reservation>(); // Inicijalizacija rezervacija, može se proširiti čitanjem iz fajla
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        public bool IsApartmentAvailable(Apartment apartment, DateTime date)
        {
            return !_reservations.Any(r => r.Apartment == apartment && r.ReservationDate == date && r.Status == ReservationStatus.Confirmed);
        }
    }
}
