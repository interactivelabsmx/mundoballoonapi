using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using OrderProductsDetails = MundoBalloonApi.business.DTOs.Entities.OrderProductsDetails;

namespace MundoBalloonApi.graphql.Orders;

public partial class OrderQueries
{
    [Authorize]
    
    public IQueryable<OrderProductsDetails> GetOrdersProductDetails(
        MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int orderDetailsProductsId)
    {
        return mapper.ProjectTo<OrderProductsDetails>(mundoBalloonContext.OrderProductDetails
            .Where(uc => uc.OrderDetailsProductsId == orderDetailsProductsId)
            .Include(uc => uc.Order).Include(uc => uc.ProductVariant));
    }
}