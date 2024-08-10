using alimenta.bem.entity.metadata;
using alimenta_bem.src.natural.person.repository;
using alimenta_bem.src.organization.repository;

namespace alimenta_bem.src.donation.repository;

public class Donation : BaseEntity
{
    public Guid naturalPersonId { get; set; }
    public virtual NaturalPerson? naturalPerson { get; set; }
    public Guid organizationId { get; set; }
    public virtual Organization? organization { get; set; }
    public string itemName { get; set; }
    public int amountDonated { get; set; }
}