using System.Security.Claims;

namespace alimenta_bem.src.modules.natural.person.useCases.create.dto.request;

public class NaturalPersonCreateRequest
{
    [FromClaim(ClaimTypes.NameIdentifier, IsRequired = true)]
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? SocialName { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public string Age { get; set; }
    public DateOnly BirthdayDate { get; set; }
    public string? Gender { get; set; }
    public string? SkinColor { get; set; }
    public bool? IsPcd { get; set; }
}