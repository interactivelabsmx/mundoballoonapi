using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;
using Orders = MundoBalloonApi.business.DTOs.Entities.Orders;

namespace MundoBalloonApi.graphql.Users;

public partial class UserOrderQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<Orders> GetOrders(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        return mapper.ProjectTo<Orders>(mundoBalloonContext.Orders.Where(uc => uc.UserId == currentUser.UserId)
            .Include(uc => uc.User));
    }
}