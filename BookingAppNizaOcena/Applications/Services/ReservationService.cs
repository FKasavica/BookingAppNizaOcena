using BookingAppNizaOcena.Repository;
using BookingAppNizaOcena.Domain.Models;
using System;
using System.Collections.Generic;

namespace BookingAppNizaOcena.Applications.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }

        public void CreateReservation(Reservation reservation)
        {
            _reservationRepository.AddReservation(reservation);
        }

        public bool IsApartmentAvailable(Apartment apartment, DateTime date)
        {
            return _reservationRepository.IsApartmentAvailable(apartment, date);
        }
    }
}
