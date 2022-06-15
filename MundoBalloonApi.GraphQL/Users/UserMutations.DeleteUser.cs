using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    public Task<bool> DeleteUser(
        string userId,
        [Service] IUsersService usersService, CancellationToken cancellationToken) => usersService.DeleteUser(userId, cancellationToken);
}