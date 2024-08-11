using alimenta_bem.helpers;
using alimenta_bem.db.context;

namespace alimenta_bem.src.modules.user.repository;

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
            .Include(u => u.roles)
            .Where(u => u.email.Equals(email))
            .Where(u => u.deletedAt.Equals(null))
            .FirstOrDefaultAsync();

        return user;
    }
    public async Task<User?> ReadOne(Guid id)
    {
        var user = await _context.Users
            .Include(u => u.roles)
            .Where(u => u.id.Equals(id))
            .Where(u => u.deletedAt.Equals(null))
            .FirstOrDefaultAsync();

        return user;
    }
}