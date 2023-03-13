using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public Task<int> GetUserCartCount(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        return mundoBalloonContext.UserCartProducts.CountAsync(uc => uc.UserId == currentUser.UserId,
            cancellationToken);
    }
}