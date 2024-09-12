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
            // Proveri da li niz values ima dovoljan broj elemenata
            if (values.Length >= 5)
            {
                Id = values[0];
                GuestEmail = values[1];
                ApartmentName = values[2];
                ReservationDate = values[3];

                // Parsiraj status rezervacije uz proveru validnosti
                if (Enum.TryParse(values[4], out ReservationStatus status))
                {
                    Status = status;
                }
                else
                {
                    throw new Exception("Invalid reservation status format.");
                }

                // Ako CSV ima više od 5 kolona, proveri dodatne informacije (ako ih ima)
                if (values.Length > 5)
                {
                    RejectionReason = values[5];  // Primer dodatne kolone, možeš proširiti po potrebi
                }
            }
            else
            {
                throw new Exception("CSV format is incorrect or missing data.");
            }
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
