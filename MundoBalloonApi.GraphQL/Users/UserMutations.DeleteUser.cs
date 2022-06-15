using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    public Task<bool> DeleteUser(
        string userId,
        [Service] IUsersService usersService, CancellationToken cancellationToken)
    {
        return usersService.DeleteUser(userId, cancellationToken);
    }
}