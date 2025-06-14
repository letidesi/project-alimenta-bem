namespace alimenta_bem.src.modules.user.useCases.authenticate.dto.response;

public class UserAuthenticateResponse
{
    public string accesstoken { get; set; }
    public string refreshtoken { get; set; }
}