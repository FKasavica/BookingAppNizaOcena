using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Applications.Utilities;

namespace BookingAppNizaOcena.Repository
{
    public class UserRepository
    {
        private const string filePath = "../../../Resources/Data/users.csv";
        private readonly Serializer<User> _serializer;
        private List<User> _users;

        public UserRepository()
        {
            _serializer = new Serializer<User>();
            _users = _serializer.FromCSV(filePath);
        }

        public User Save(User user)
        {
            _users.Add(user);
            _serializer.ToCSV(filePath, _users);
            return user;
        }

        public User GetByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetAll()
        {
            return _users;
        }
    }
}
