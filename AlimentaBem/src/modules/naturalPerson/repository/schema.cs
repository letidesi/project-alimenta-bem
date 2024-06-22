using alimenta.bem.entity.metadata;
using alimenta.bem.user.repository;

namespace alimenta.bem.natural.person.repository;

public class NaturalPerson : BaseEntity
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? SocialName { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string Age { get; set; }
    public DateOnly BirthdayDate { get; set; }
    // public string Neighborhood { get; set; } = Parque Xerém
    // public string City { get; set; } = "Duque de Caxias";
    // public string State { get; set; } = "Rio de Janeiro";
    public string? Gender { get; set; }
    public string? SkinColor { get; set; }
    public bool? IsPcd { get; set; }
}