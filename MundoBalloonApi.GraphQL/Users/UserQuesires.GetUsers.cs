using AutoMapper;
using FirebaseAdmin.Auth;
using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Users;

public partial class UserQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    [UsePaging]
    public IQueryable<FireBaseUser> GetUsers([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        //UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(u.UserId);
        var users = mundoBalloonContext.Users.Select(u => new FireBaseUser
        {
            Id = u.Id,
            UserId = u.UserId ?? "",
            Email = FirebaseAuth.DefaultInstance.GetUserAsync(u.UserId).Result.Email,
            DisplayName = FirebaseAuth.DefaultInstance.GetUserAsync(u.UserId).Result.DisplayName,
            PhoneNumber = FirebaseAuth.DefaultInstance.GetUserAsync(u.UserId).Result.PhoneNumber
        }).AsQueryable();
        return users;
    }
}