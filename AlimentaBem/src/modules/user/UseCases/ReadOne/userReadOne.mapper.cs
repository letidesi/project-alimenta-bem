using alimenta_bem.src.modules.user.repository;
using alimenta_bem.src.modules.user.useCases.readOne.request;
using alimenta_bem.src.modules.user.useCases.readOne.response;

namespace alimenta_bem.src.modules.user.useCases.readOne.mapper;

public class UserReadOneMapper : Mapper<UserReadOneRequest, UserReadOneResponse, User>
{

    public override User ToEntity(UserReadOneRequest req) => new()
    {
        id = req.userId,
    };

    public override UserReadOneResponse FromEntity(User u) => new()
    {
        userId = u.id,
        name = u.name,
        email = u.email,
        password = u.passwordHash,
    };
}