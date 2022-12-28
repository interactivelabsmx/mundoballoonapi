using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartMutations
{
    [Authorize]
    public Task<UserAddresses> UpdateUserAddresses(
    int userAddressesId, [GlobalState("currentUser")] CurrentUser currentUser, string address1, string address2, string city, string state, string country, string zipCode,
    [Service] IUsersService usersService,
    CancellationToken cancellationToken)
    {
        return usersService.UpdateUserAddresses(userAddressesId, currentUser.UserId, address1, address2, city, state, country, zipCode, cancellationToken);
    }
}