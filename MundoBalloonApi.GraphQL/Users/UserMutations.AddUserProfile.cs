using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    [Authorize]
    public Task<UserProfile> AddUserProfile(
        [GlobalState("currentUser")] CurrentUser currentUser, string firstName, string lastName, int phoneNumber,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.AddUserProfile(currentUser.UserId, firstName, lastName, phoneNumber, cancellationToken);
    }
}