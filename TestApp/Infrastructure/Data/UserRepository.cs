namespace TestApp.Infrastructure.Data;
using TestApp.Domain.Repositories;
using TestApp.Domain.Entities;
using System;
public class UserRepository : IUserRepository
{
    // ... implementation using Entity Framework Core or other ORM
    public User GetById(Guid id){
        throw new NotImplementedException();
    }
    public void Save(User user){
        throw new NotImplementedException();
    }
}