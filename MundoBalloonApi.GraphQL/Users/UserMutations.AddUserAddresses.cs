using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserMutations
{
    [Authorize]
    public Task<UserAddresses> AddUserAddresses(string address1, string? address2, string city,
        string state, string country, string zipCode,
        [GlobalState("currentUser")] CurrentUser currentUser,
        [Service] IUsersService usersService,
        CancellationToken cancellationToken)
    {
        return usersService.AddUserAddresses(currentUser.UserId, address1, address2 ?? "", city, state, country,
            zipCode, cancellationToken);
    }
}