using alimenta.bem.helpers;
using alimenta.bem.db.context;

namespace alimenta.bem.user.repository;

public class UserData : IUserData
{
    private readonly AlimentaBemContext _context;

    public UserData(AlimentaBemContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<User> Create(User user)
    {
        user = (User)WhiteSpaces.RemoveFromAllStringProperty(user);

        _context.Users.Add(user);

        _ = await _context.SaveChangesAsync();

        return user;
    }
    public async Task<User?> ReadOneByEmail(string email)
    {
        var user = await _context.Users
            .Include(u => u.Roles)
            .Where(u => u.Email.Equals(email))
            .Where(u => u.DeletedAt.Equals(null))
            .FirstOrDefaultAsync();

        return user;
    }
}