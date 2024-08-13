namespace TestApp.Domain.Repositories;
using TestApp.Domain.Entities;
public interface IUserRepository
{
    User GetById(Guid id);
    void Save(User user);
}