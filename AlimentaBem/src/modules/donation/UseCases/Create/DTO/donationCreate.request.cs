namespace alimenta_bem.src.modules.donation.useCases.create.dto.request;

public class DonationCreateRequest
{
    public Guid naturalPersonId { get; set; }
    public Guid organizationId { get; set; }
    public string itemName { get; set; }
    public int amountDonated { get; set; }
}