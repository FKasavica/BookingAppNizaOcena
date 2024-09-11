using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Applications.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace BookingAppNizaOcena.Repository
{
    public class UserRepository
    {
        private static readonly string filePath = @"D:\GitHub\BookingAppNizaOcena\BookingAppNizaOcena\Resources\Data\users.csv";
        private readonly Serializer<User> _serializer;
        private List<User> _users;

        public UserRepository()
        {
            _serializer = new Serializer<User>();
            _users = _serializer.FromCSV(filePath) ?? new List<User>(); // Osiguraj da lista nije null
        }

        public User Save(User user)
        {
            var existingUserByJMBG = _users.FirstOrDefault(u => u.JMBG == user.JMBG);
            var existingUserByEmail = _users.FirstOrDefault(u => u.Email == user.Email);

            if (existingUserByJMBG != null)
            {
                throw new Exception("A user with the same JMBG already exists.");
            }

            if (existingUserByEmail != null)
            {
                throw new Exception("A user with the same Email already exists.");
            }

            _users.Add(user);
            _serializer.ToCSV(filePath, _users);
            return user;
        }

        public User? GetByEmail(string email) // Obeleži kao nullable tip
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetAll()
        {
            return _users;
        }
    }
}
