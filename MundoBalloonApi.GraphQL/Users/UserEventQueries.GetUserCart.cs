using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using UserCart = MundoBalloonApi.business.DTOs.Entities.UserCart;

namespace MundoBalloonApi.graphql.Users;

public partial class UserEventQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserCart> GetUserCart([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        var userCart = mundoBalloonContext.UserCarts.Where(uc => uc.UserId == currentUser.UserId)
            .Include(uc => uc.ProductVariant)
            .ThenInclude(pv => pv!.ProductVariantMedia);
        return mapper.ProjectTo<UserCart>(userCart);
    }
}