using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;
using System.Collections.Generic;

namespace BookingAppNizaOcena.Applications.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }

        public User Register(User newUser)
        {
            return _userRepository.Save(newUser);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
