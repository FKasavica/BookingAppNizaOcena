using BookingAppNizaOcena.Applications.UtilityInterfaces;
using System.Collections.Generic;

namespace BookingAppNizaOcena.Domain.Models
{
    public class Hotel : ISerializable
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int YearBuilt { get; set; }
        public Dictionary<string, Apartment> Apartments { get; set; }
        public int StarRating { get; set; }
        public string OwnerJMBG { get; set; }

        public Hotel()
        {
            Apartments = new Dictionary<string, Apartment>();
        }

        public Hotel(string code, string name, int yearBuilt, int starRating, string ownerJMBG)
        {
            Code = code;
            Name = name;
            YearBuilt = yearBuilt;
            Apartments = new Dictionary<string, Apartment>();
            StarRating = starRating;
            OwnerJMBG = ownerJMBG;
        }

        public void FromCSV(string[] values)
        {
            Code = values[0];
            Name = values[1];
            YearBuilt = int.Parse(values[2]);
            StarRating = int.Parse(values[3]);
            OwnerJMBG = values[4];
        }

        public string[] ToCSV()
        {
            return new string[]
            {
                Code,
                Name,
                YearBuilt.ToString(),
                StarRating.ToString(),
                OwnerJMBG
            };
        }
    }
}
