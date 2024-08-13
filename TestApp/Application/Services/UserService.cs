namespace TestApp.Application.Services;
using TestApp.Application.Interfaces;
using TestApp.Infrastructure.Data;
using TestApp.Domain.Repositories;
using TestApp.Domain.Entities;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository  
 userRepository)
    {
        _userRepository = userRepository;  

    }

    public void RegisterUser(string name, string email)
    {
        var user = new User(Guid.NewGuid(), name, new Email(email));
        _userRepository.Save(user);
    }
}