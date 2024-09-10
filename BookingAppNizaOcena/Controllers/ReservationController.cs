using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using System.Collections.Generic;

namespace BookingAppNizaOcena.Controllers
{
    public class ReservationController
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public void CreateReservation(User guest, Apartment apartment, string reservationDate)
        {
            var reservation = new Reservation
            {
                GuestEmail = guest.Email,
                ApartmentName = apartment.Name,
                ReservationDate = reservationDate,
                Status = ReservationStatus.Pending
            };
            _reservationService.CreateReservation(reservation);
        }

        public void CancelReservation(Reservation reservation)
        {
            _reservationService.CancelReservation(reservation);
        }

        public List<Reservation> GetReservationsByGuest(string guestEmail)
        {
            return _reservationService.GetReservationsByGuest(guestEmail);
        }

        public List<Reservation> GetPendingReservations(string guestEmail)
        {
            return _reservationService.GetPendingReservationsByGuest(guestEmail);
        }

        public List<Reservation> GetConfirmedReservations(string guestEmail)
        {
            return _reservationService.GetConfirmedReservationsByGuest(guestEmail);
        }

        public List<Reservation> GetRejectedReservations(string guestEmail)
        {
            return _reservationService.GetRejectedReservationsByGuest(guestEmail);
        }
    }
}
