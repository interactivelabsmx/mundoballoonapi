using AutoMapper;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using OrderProductsDetails = MundoBalloonApi.business.DTOs.Entities.OrderProductsDetails;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<OrderProductsDetails> GetOrdersProductDetails([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int orderDetailsProductsId)
    {
        return mapper.ProjectTo<OrderProductsDetails>(mundoBalloonContext.OrderProductDetails.Where(uc => uc.OrderDetailsProductsId == orderDetailsProductsId));
    }
    
}