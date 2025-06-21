namespace alimenta_bem.src.modules.naturalPerson.useCases.readOne.response;

public class NaturalPersonReadOneResponse
{
    public Guid naturalPersonId { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public Guid userId { get; set; }
    public string? socialName { get; set; }
    public string age { get; set; }
    public DateOnly birthdayDate { get; set; }
    public string skinColor { get; set; }
    public string gender { get; set; }
    public bool? isPcd { get; set; }
}