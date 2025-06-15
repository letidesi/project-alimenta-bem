namespace alimenta_bem.src.modules.donation.useCases.create.dto.response;

public class DonationCreateResponse
{
    public Guid id { get; set; }
    public Guid naturalPersonId { get; set; }
    public Guid organizationId { get; set; }
    public string itemName { get; set; }
    public int amountDonated { get; set; }

    public DateTimeOffset createdAt { get; set; }
    public DateTimeOffset? updatedAt { get; set; }
}