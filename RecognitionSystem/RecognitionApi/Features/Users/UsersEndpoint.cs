using ApplicationCore.Features.Users.Queries;
using MediatR;

namespace RecognitionApi.Features.Users;

public static class UsersEndpoint
{
    public static RouteGroupBuilder MapUsersApi(this RouteGroupBuilder group)
    {
        group.MapGet("/searchUser", (ISender m, string name) => m.Send(new SearchUserByNameQuery(name)));
        return group;
    }
    
}