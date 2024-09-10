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
            _reservations = LoadReservations();
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

        public void Add(Reservation reservation)
        {
            _reservations.Add(reservation);
            SaveReservations();
        }

        public void CancelReservation(Reservation reservation)
        {
            var existingReservation = _reservations.FirstOrDefault(r => r.Id == reservation.Id);
            if (existingReservation != null)
            {
                existingReservation.Status = ReservationStatus.Canceled;
                SaveReservations();
            }
        }

        private List<Reservation> LoadReservations()
        {
            // Učitavanje rezervacija iz CSV-a
            return new List<Reservation>();
        }

        private void SaveReservations()
        {
            // Čuvanje rezervacija u CSV-u
        }
    }
}
