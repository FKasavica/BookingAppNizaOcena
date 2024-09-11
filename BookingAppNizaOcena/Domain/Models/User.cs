using BookingAppNizaOcena.Applications.UtilityInterfaces;

namespace BookingAppNizaOcena.Domain.Models
{
    public class User : ISerializable
    {
        public string JMBG { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public UserType UserType { get; set; }
        public bool IsBlocked { get; set; } // Dodato svojstvo IsBlocked

        public User() { }

        public User(string jmbg, string email, string password, string firstName, string lastName, string mobilePhone, UserType userType, bool isBlocked = false)
        {
            JMBG = jmbg;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            UserType = userType;
            IsBlocked = isBlocked; // Inicijalizovano sa default vrednošću false
        }

        public void FromCSV(string[] values)
        {
            if (values.Length < 8)
            {
                throw new IndexOutOfRangeException("Niz values nema dovoljno elemenata za očekivani format.");
            }

            JMBG = values[0];
            Email = values[1];
            Password = values[2];
            FirstName = values[3];
            LastName = values[4];
            MobilePhone = values[5];
            UserType = (UserType)Enum.Parse(typeof(UserType), values[6]);
            IsBlocked = bool.Parse(values[7]); // Dodata obrada za IsBlocked
        }

        public string[] ToCSV()
        {
            return new string[]
            {
                JMBG,
                Email,
                Password,
                FirstName,
                LastName,
                MobilePhone,
                UserType.ToString(),
                IsBlocked.ToString() // Dodato u CSV serijalizaciju
            };
        }
    }

    public enum UserType
    {
        Administrator,
        Guest,
        Owner
    }
}
