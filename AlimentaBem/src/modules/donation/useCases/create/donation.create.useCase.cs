using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta_bem.src.donation.repository;

namespace alimenta_bem.src.modules.donation.useCases.create.useCase;

public class DonationCreateUseCase
{
    private Localizer _localizer;
    public IDonationData _donationData;
    public DonationCreateUseCase(AlimentaBemContext context, Localizer localizer)
    {
        _localizer = localizer;
        _donationData = new DonationData(context);
    }

    public async Task<Donation> exec(Donation naturalPerson)
    {
        var donation = await _donationData.Create(naturalPerson);
        if (donation is null)
            throw new Exception(_localizer["donation:IndividualCreationFailed"]);

        return donation;
    }
}