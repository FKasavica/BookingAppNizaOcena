using BookingAppNizaOcena.Applications.Services;
using BookingAppNizaOcena.Domain.Models;
using System.Collections.Generic;

namespace BookingAppNizaOcena.Controllers
{
    public class UserController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // Metoda za prijavu korisnika
        public User Login(string email, string password)
        {
            return _userService.Login(email, password);
        }

        // Metoda za registraciju novog korisnika
        public User Register(User newUser)
        {
            // Provera da li već postoji korisnik sa istim emailom
            var existingUser = _userService.GetByEmail(newUser.Email);
            if (existingUser != null)
            {
                return null; // Korisnik već postoji
            }

            return _userService.Register(newUser);
        }

        // Metoda za dobijanje svih korisnika
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
    }
}
