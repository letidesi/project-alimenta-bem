using alimenta.bem.entity.metadata;

namespace alimenta_bem.src.modules.donation.useCases.create.dto.response;

public class DonationCreateResponse : BaseEntity
{
    public Guid naturalPersonId { get; set; }
    public Guid organizationId { get; set; }
    public string itemName { get; set; }
    public int amountDonated { get; set; }
}