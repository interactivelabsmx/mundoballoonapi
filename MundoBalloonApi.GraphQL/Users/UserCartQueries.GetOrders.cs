using AutoMapper;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using Orders = MundoBalloonApi.business.DTOs.Entities.Orders;

namespace MundoBalloonApi.graphql.Users;

public partial class UserCartQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<Orders> GetOrders([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper,  string userId)
    {
        return mapper.ProjectTo<Orders>(mundoBalloonContext.Orders.Where(u => u.UserId == userId));
    }
}