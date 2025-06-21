namespace alimenta_bem.src.modules.user.useCases.readOne.response;

public class UserReadOneResponse
{
    public Guid userId { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
}