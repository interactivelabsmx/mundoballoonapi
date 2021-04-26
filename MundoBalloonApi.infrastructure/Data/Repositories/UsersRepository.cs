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
    }
}