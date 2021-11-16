using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Requests;
using MundoBalloonApi.graphql.Users.Requests;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    public CreateUserPayload CreateUser(
        CreateUserRequest input,
        [Service] IUsersService usersService)
    {
        var user = usersService.CreateOrGetUser(new CreateUserRequest
        {
            UserId = input.UserId
        });
        return new CreateUserPayload(user);
    }
}