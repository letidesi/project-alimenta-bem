using alimenta_bem.helpers;
using alimenta_bem.db.context;

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
    public async Task<bool> Check_Natural_Person_Already_Exists_With_Same_User(NaturalPerson naturalPerson)
    {
        return await _context.NaturalPersons.AnyAsync(n => n.userId == naturalPerson.userId);
    }
    public async Task<bool> Check_Rg_Already_Exists(Guid id, string rg)
    {
        return await _context.NaturalPersons.Where(np => np.id != id && np.rg.Equals(rg)).AnyAsync();
    }
    public async Task<bool> Check_Cpf_Already_Exists(Guid id, string cpf)
    {
        return await _context.NaturalPersons.Where(np => np.id != id && np.cpf.Equals(cpf)).AnyAsync();
    }

}