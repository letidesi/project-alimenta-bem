namespace alimenta_bem.src.modules.user.useCases.authenticate.dto.response;

public class UserAuthenticateResponse
{
    public string Accesstoken { get; set; }
    public string Refreshtoken { get; set; }
}