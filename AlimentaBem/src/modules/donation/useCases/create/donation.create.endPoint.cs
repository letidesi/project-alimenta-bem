using alimenta_bem.helpers;
using alimenta_bem.db.context;
using alimenta.bem.src.modules.donation.useCases.create.mapper;
using alimenta_bem.src.modules.donation.useCases.create.dto.request;
using alimenta_bem.src.modules.donation.useCases.create.dto.response;
using alimenta_bem.src.modules.donation.useCases.create.useCase;

namespace alimenta_bem.src.modules.donation.useCases.create.endpoint;

public class DonationCreateEndPoint : Endpoint<DonationCreateRequest, DonationCreateResponse, DonationCreateMapper>
{
    public AlimentaBemContext _context { get; init; }
    public Localizer _localizer { get; init; }

    public override void Configure()
    {
        Post("donation");
        Options(n => n.WithTags("donation"));
        Summary(s =>
        {
            s.Summary = "Create a new natural person";
            s.Description = "Register a natural person on the platform";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(DonationCreateRequest req, CancellationToken ct)
    {
        try
        {
            var donationCreateUseCase = new DonationCreateUseCase(_context, _localizer);

            var donation = Map.ToEntity(req);

            var create_donation = await donationCreateUseCase.exec(donation);

            var created_donation = Map.FromEntity(create_donation);

            await SendAsync(created_donation);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}