using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.natural.person.repository;

public class NaturalPersonData : INaturalPersonData
{
    private readonly AlimentaBemContext _context;

    public NaturalPersonData(AlimentaBemContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<NaturalPerson> Create(NaturalPerson naturalPerson)
    {
        naturalPerson = (NaturalPerson)WhiteSpaces.RemoveFromAllStringProperty(naturalPerson);

        _context.NaturalPersons.Add(naturalPerson);

        _ = await _context.SaveChangesAsync();

        return naturalPerson;
    }

    public Task<User?> GetUserByEmail(string email)
    {
        return _context.Users.Where(u => u.email == email).FirstOrDefaultAsync();
    }

    public Task<NaturalPerson?> ReadNaturalPersonByUser(Guid userId)
    {
        return _context.NaturalPersons
            .Where(n => n.userId == userId)
            .Select(n => new NaturalPerson
            {
                id = n.id,
                name = n.name,
                socialName = n.socialName,
                emailUser = n.emailUser,
                age = n.age,
                birthdayDate = n.birthdayDate,
                skinColor = n.skinColor,
                gender = n.gender,
                isPcd = n.isPcd,
                userId = n.userId
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<NaturalPerson>> ReadList()
    {
        return await _context.NaturalPersons.ToListAsync();
    }

    public async Task<NaturalPerson> Update(NaturalPerson naturalPerson)
    {
        naturalPerson = (NaturalPerson)WhiteSpaces.RemoveFromAllStringProperty(naturalPerson);

        _context.NaturalPersons.Update(naturalPerson);

        _ = await _context.SaveChangesAsync();

        return naturalPerson;
    }

    public async Task<NaturalPerson> CheckNaturalPersonAlreadyExist(NaturalPerson naturalPerson)
    {
        return await _context.NaturalPersons
            .Where(n => n.userId == naturalPerson.userId)
            .Select(n => new NaturalPerson
            {
                id = n.id,
                name = n.name,
                socialName = n.socialName,
                emailUser = n.emailUser,
                age = n.age,
                birthdayDate = n.birthdayDate,
                skinColor = n.skinColor,
                isPcd = n.isPcd,
                userId = n.userId
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> CheckNaturalPersonAlreadyExistsWithSameUser(NaturalPerson naturalPerson)
    {
        return await _context.NaturalPersons.AnyAsync(n => n.userId == naturalPerson.userId);
    }
}