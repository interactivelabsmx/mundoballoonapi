using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.graphql.Users.Responses;
using MundoBalloonApi.infrastructure.Data.Models;
using UserCartProduct = MundoBalloonApi.business.DTOs.Entities.UserCartProduct;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public async Task<UserCart> GetUserCart([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser,
        CancellationToken cancellationToken)
    {
        var products = mapper.Map<IEnumerable<UserCartProduct>>(mundoBalloonContext.UserCartProducts
            .Where(uc => uc.UserId == currentUser.UserId)
            .Include(uc => uc.ProductVariant)
            .ThenInclude(pv => pv!.ProductVariantMedia).AsAsyncEnumerable());
        var subtotal = await mundoBalloonContext.UserCartProducts.Where(uc => uc.UserId == currentUser.UserId)
            .SumAsync(cp => cp.Price, cancellationToken);
        const int tax = 0;

        return new UserCart
        {
            Products = products,
            Subtotal = subtotal,
            Total = subtotal,
            Tax = tax
        };
    }
}