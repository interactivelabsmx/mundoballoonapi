using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using UserCartProduct = MundoBalloonApi.business.DTOs.Entities.UserCartProduct;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserCartProduct> GetUserCartProducts(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        return mapper.ProjectTo<UserCartProduct>(mundoBalloonContext.UserCartProducts
            .Where(uc => uc.UserId == currentUser.UserId)
            .Include(uc => uc.ProductVariant));
    }
}