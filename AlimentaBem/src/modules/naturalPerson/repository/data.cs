using alimenta.bem.helpers;
using alimenta.bem.db.context;

namespace alimenta.bem.natural.person.repository;

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
    public async Task<bool> Check_Natural_Person_Already_Exists_With_Same_User(NaturalPerson naturalPerson)
    {
        return await _context.NaturalPersons.AnyAsync(n => n.UserId == naturalPerson.UserId);
    }
    public async Task<bool> Check_Rg_Already_Exists(Guid Id, string Rg)
    {
        return await _context.NaturalPersons.Where(np => np.Id != Id && np.Rg.Equals(Rg)).AnyAsync();
    }
    public async Task<bool> Check_Cpf_Already_Exists(Guid Id, string Cpf)
    {
        return await _context.NaturalPersons.Where(np => np.Id != Id && np.Cpf.Equals(Cpf)).AnyAsync();
    }

}