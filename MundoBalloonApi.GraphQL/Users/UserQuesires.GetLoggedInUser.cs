using System.Linq;
using AutoMapper;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.DTOs.Models;
using MundoBalloonApi.infrastructure.Data.Models;
using User = MundoBalloonApi.business.DTOs.Models.User;

namespace MundoBalloonApi.graphql.Users
{
    public partial class UserQueries
    {
        [Authorize]
        [UseDbContext(typeof(MundoBalloonContext))]
        public User? GetLoggedInUser([ScopedService] MundoBalloonContext mundoBalloonContext,
            [Service] IMapper mapper, [GlobalStateAttribute("currentUser")] CurrentUser currentUser)
        {
            var result = mundoBalloonContext.Users.Where(u => u.UserId == currentUser.UserId)
                .Include(u => u.UserProfile);
            var user = result.FirstOrDefault();
            return mapper.Map<User>(user);
        }
    }
}