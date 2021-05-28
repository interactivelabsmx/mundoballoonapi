using System.Threading.Tasks;
using AutoMapper;
using FirebaseAdmin.Auth;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Models;
using MundoBalloonApi.business.DTOs.Requests;
using MundoBalloonApi.infrastructure.Data.Contracts;

namespace MundoBalloonApi.business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public User CreateOrGetUser(CreateUserRequest createUserRequest)
        {
            var currentUser = _usersRepository.GetById(createUserRequest.UserId);
            if (currentUser != null) return _mapper.Map<User>(currentUser);

            var user = _mapper.Map<infrastructure.Data.Models.User>(createUserRequest);
            var result = _usersRepository.Create(user);
            return _mapper.Map<User>(result);
        }

        public async Task<UserRecord?> GetFirebaseUserById(string userId)
        {
            try
            {
                var auth = FirebaseAuth.DefaultInstance;
                var userRecord = await auth.GetUserAsync(userId);
                return userRecord;
            }
            catch (FirebaseAuthException e) when (e.Message.Contains($"Failed to get user with uid: {userId}"))
            {
                return null;
            }
        }
    }
}