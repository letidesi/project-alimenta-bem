using alimenta_bem.helpers;
using alimenta_bem.db.context;

namespace alimenta_bem.src.donation.repository;

public class DonationData : IDonationData
{
    private readonly AlimentaBemContext _context;

    public DonationData(AlimentaBemContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Donation> Create(Donation naturalPerson)
    {
        naturalPerson = (Donation)WhiteSpaces.RemoveFromAllStringProperty(naturalPerson);

        _context.Donations.Add(naturalPerson);

        _ = await _context.SaveChangesAsync();

        return naturalPerson;
    }
}