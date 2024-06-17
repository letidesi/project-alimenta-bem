namespace alimenta.bem.user.repository;

public interface IUserData
{
    Task<User> Create(User user);
    Task<User?> ReadOneByEmail(string email);
}