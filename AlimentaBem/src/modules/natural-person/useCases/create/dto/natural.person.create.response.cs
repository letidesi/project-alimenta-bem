using alimenta.bem.entity.metadata;

namespace alimenta_bem.src.modules.natural.person.useCases.create.dto.response;

public class NaturalPersonCreateResponse : BaseEntity
{
    public Guid userId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string? socialName { get; set; }
    public string age { get; set; }
    public DateOnly birthdayDate { get; set; }
    public string? gender { get; set; }
    public string? skinColor { get; set; }
    public bool? isPcd { get; set; }
}