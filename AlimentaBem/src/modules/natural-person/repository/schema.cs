using alimenta.bem.entity.metadata;
using alimenta_bem.src.natural.person.@enum;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.src.natural.person.repository;

public class NaturalPerson : BaseEntity
{
    public Guid userId { get; set; }
    public User? user { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string? socialName { get; set; }
    public string cpf { get; set; }
    public string rg { get; set; }
    public string age { get; set; }
    public DateOnly birthdayDate { get; set; }
    // public string Neighborhood { get; set; } = Parque Xerém
    // public string City { get; set; } = "Duque de Caxias";
    // public string State { get; set; } = "Rio de Janeiro";
    public Gender? gender { get; set; }
    public SkinColor? skinColor { get; set; }
    public bool? isPcd { get; set; }
}