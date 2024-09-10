using BookingAppNizaOcena.Applications.UtilityInterfaces;

namespace BookingAppNizaOcena.Domain.Models
{
    public class Apartment : ISerializable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomCount { get; set; }
        public int MaxGuests { get; set; }

        public Apartment() { }

        public Apartment(string name, string description, int roomCount, int maxGuests)
        {
            Name = name;
            Description = description;
            RoomCount = roomCount;
            MaxGuests = maxGuests;
        }

        public void FromCSV(string[] values)
        {
            Name = values[0];
            Description = values[1];
            RoomCount = int.Parse(values[2]);
            MaxGuests = int.Parse(values[3]);
        }

        public string[] ToCSV()
        {
            return new string[]
            {
                Name,
                Description,
                RoomCount.ToString(),
                MaxGuests.ToString()
            };
        }
    }
}
