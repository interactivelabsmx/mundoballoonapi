using System.Linq;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MundoBalloonContext _context;

        public UsersRepository(MundoBalloonContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            var profile = new UserProfile();
            _context.Users.Add(user);
            profile.UserId = user.Id;
            _context.UserProfiles.Add(profile);
            _context.SaveChanges();
            return user;
        }
    }
}