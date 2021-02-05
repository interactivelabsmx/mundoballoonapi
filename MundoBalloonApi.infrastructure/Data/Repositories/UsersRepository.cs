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

        public UserProfile Create(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            _context.SaveChanges();
            return userProfile;
        }

        public UserProfile Update(UserProfile userProfile)
        {
            var existingUSer = _context.UserProfiles.FirstOrDefault(u => u.UserId == userProfile.UserId);
            if (existingUSer != null) return existingUSer;
            _context.UserProfiles.Update(userProfile);
            _context.SaveChanges();
            return userProfile;
        }
    }
}