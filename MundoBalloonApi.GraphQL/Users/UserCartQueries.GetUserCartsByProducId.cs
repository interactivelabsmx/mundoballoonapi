using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using UserCart = MundoBalloonApi.business.DTOs.Entities.UserCartProduct;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<UserCart> GetUserCartsByProductId(
        [Service(ServiceKind.Pooled)] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser, int productId)
    {
        return mapper.ProjectTo<UserCart>(mundoBalloonContext.UserCartProducts
            .Where(uc => uc.UserId == currentUser.UserId)
            .Include(uc => uc.ProductVariant).Where(uc => uc.ProductVariant.ProductId == productId));
    }
}