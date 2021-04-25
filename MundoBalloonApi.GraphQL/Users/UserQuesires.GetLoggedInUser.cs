using System;
using System.Linq;
using AutoMapper;
using GreenDonut;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Models;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Users
{
    public partial class UserQueries
    {
        [Authorize]
        [UseDbContext(typeof(MundoBalloonContext))]
        public business.DTOs.Models.User? GetLoggedInUser([ScopedService] MundoBalloonContext mundoBalloonContext, [Service] IMapper mapper, [GlobalStateAttribute("currentUser")]CurrentUser currentUser)
        {
            var result = mundoBalloonContext.Users.Where(u => u.Id == 1).Include(u => u.UserProfile);
            var user = result.FirstOrDefault();
            return mapper.Map<business.DTOs.Models.User>(user);
        }
    }
}