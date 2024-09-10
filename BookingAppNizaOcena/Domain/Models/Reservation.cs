using BookingAppNizaOcena.Domain.Models;

namespace BookingAppNizaOcena.Domain.Models
{
    public class Reservation
    {
        public Apartment Apartment { get; set; }
        public User Guest { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; }
        public string RejectionReason { get; set; } // Razlog odbijanja, ukoliko postoji
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Rejected
    }
}
