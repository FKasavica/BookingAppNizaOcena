using BookingAppNizaOcena.Domain.Models;
using BookingAppNizaOcena.Repository;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User? Login(string email, string password) // Obeleži kao nullable tip
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

    public User? GetByEmail(string email) // Obeleži kao nullable tip
    {
        return _userRepository.GetByEmail(email);
    }

    public List<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }
}
