using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContextFactory<MundoBalloonContext> _contextFactory;

        public UsersRepository(IDbContextFactory<MundoBalloonContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public User? GetById(string userId)
        {
            var context = _contextFactory.CreateDbContext();
            using (context)
            {
                return context.Users.FirstOrDefault(u => u.UserId == userId);
            }
        }

        public User Create(User user)
        {
            var context = _contextFactory.CreateDbContext();
            using (context)
            {
                context.Add(user);
                context.SaveChanges();
            }

            return user;
        }

        public List<UserClaim> GetUserClaims(string userId)
        {
            var context = _contextFactory.CreateDbContext();
            using (context)
            {
                var userClaims =  context.UserClaims.Where(uc => uc.UserId == userId).Include(uc => uc.Claim).ToList();
                return userClaims;
            } 
        }
    }
}