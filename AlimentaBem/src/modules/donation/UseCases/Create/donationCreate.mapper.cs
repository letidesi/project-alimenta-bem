using alimenta_bem.src.donation.repository;
using alimenta_bem.src.modules.donation.useCases.create.dto.request;
using alimenta_bem.src.modules.donation.useCases.create.dto.response;

namespace alimenta.bem.src.modules.donation.useCases.create.mapper;

public class DonationCreateMapper : Mapper<DonationCreateRequest, DonationCreateResponse, Donation>
{

    public override Donation ToEntity(DonationCreateRequest req) => new()
    {
        naturalPersonId = req.naturalPersonId,
        organizationId = req.organizationId,
        itemName = req.itemName,
        amountDonated = req.amountDonated
    };

    public override DonationCreateResponse FromEntity(Donation d) => new()
    {
        id = d.id,
        naturalPersonId = d.naturalPersonId,
        organizationId = d.organizationId,
        itemName = d.itemName,
        amountDonated = d.amountDonated,
        createdAt = d.createdAt,
        updatedAt = d.updatedAt
    };
}