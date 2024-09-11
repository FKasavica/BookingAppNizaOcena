using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppNizaOcena.Applications.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public bool IsApartmentAvailable(string apartmentName, DateTime reservationDate)
        {
            var existingReservations = _reservationRepository.GetReservationsByApartment(apartmentName);
            return !existingReservations.Any(r => r.ReservationDate == reservationDate.ToString("yyyy-MM-dd"));
        }

        public List<Reservation> GetReservationsByGuest(string guestEmail)
        {
            return _reservationRepository.GetReservationsByGuest(guestEmail);
        }

        public List<Reservation> GetPendingReservationsByGuest(string guestEmail)
        {
            return _reservationRepository.GetReservationsByStatus(guestEmail, ReservationStatus.Pending);
        }

        public List<Reservation> GetConfirmedReservationsByGuest(string guestEmail)
        {
            return _reservationRepository.GetReservationsByStatus(guestEmail, ReservationStatus.Confirmed);
        }

        public List<Reservation> GetRejectedReservationsByGuest(string guestEmail)
        {
            return _reservationRepository.GetReservationsByStatus(guestEmail, ReservationStatus.Rejected);
        }

        public List<Reservation> GetReservationsByApartment(string apartmentName)
        {
            return _reservationRepository.GetReservationsByApartment(apartmentName);
        }

        public void CreateReservation(Reservation reservation)
        {
            _reservationRepository.Save(reservation);
        }

        public void CancelReservation(Reservation reservation)
        {
            _reservationRepository.CancelReservation(reservation);
        }
    }
}
