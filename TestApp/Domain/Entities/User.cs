namespace TestApp.Domain.Entities;
public class User
{
    public Guid Id { get; }
    public string Name { get; }
    public Email Email { get; }

    // ...
    public User(Guid guid, string name, Email email)
    {

    }
}