using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Orders;

public partial class OrderQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<business.DTOs.Entities.Orders> GetOrders(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, [GlobalState("currentUser")] CurrentUser currentUser)
    {
        return mapper.ProjectTo<business.DTOs.Entities.Orders>(mundoBalloonContext.Orders
            .Where(uc => uc.UserId == currentUser.UserId)
            .Include(uc => uc.User));
    }
}