using BookingAppNizaOcena.Applications.UtilityInterfaces;
using System;

namespace BookingAppNizaOcena.Domain.Models
{
    public class Reservation : ISerializable
    {
        public string Id { get; set; }
        public string GuestEmail { get; set; }
        public string ApartmentName { get; set; }
        public string ReservationDate { get; set; }
        public ReservationStatus Status { get; set; }
        public string RejectionReason { get; set; }

        public Reservation() { }

        public Reservation(string id, string guestEmail, string apartmentName, string reservationDate, ReservationStatus status, string rejectionReason = "")
        {
            Id = id;
            GuestEmail = guestEmail;
            ApartmentName = apartmentName;
            ReservationDate = reservationDate;
            Status = status;
            RejectionReason = rejectionReason;
        }

        public void FromCSV(string[] values)
        {
            Id = values[0];
            GuestEmail = values[1];
            ApartmentName = values[2];
            ReservationDate = values[3];
            Status = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), values[4]);
            RejectionReason = values.Length > 5 ? values[5] : "";
        }

        public string[] ToCSV()
        {
            return new string[]
            {
                Id,
                GuestEmail,
                ApartmentName,
                ReservationDate,
                Status.ToString(),
                RejectionReason
            };
        }
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Rejected,
        Canceled
    }
}
