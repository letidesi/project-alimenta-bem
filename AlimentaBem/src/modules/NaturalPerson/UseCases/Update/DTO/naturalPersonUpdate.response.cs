using alimenta.bem.entity.metadata;

namespace alimenta_bem.src.modules.natural.person.useCases.update.dto.response;

public class NaturalPersonUpdateResponse : BaseEntity
{
    public string name { get; set; }
    public string? socialName { get; set; }
    public string emailUser { get; set; }
    public string age { get; set; }
    public DateOnly birthdayDate { get; set; }
    public string? gender { get; set; }
    public string? skinColor { get; set; }
    public bool? isPcd { get; set; }
}