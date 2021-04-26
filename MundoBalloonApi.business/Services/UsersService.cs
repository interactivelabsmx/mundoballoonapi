using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Requests;
using MundoBalloonApi.infrastructure.Data.Contracts;
using User = MundoBalloonApi.business.DTOs.Models.User;

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

        public User Create(CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<infrastructure.Data.Models.User>(createUserRequest);
            var result = _usersRepository.Create(user);
            return _mapper.Map<User>(result);
        }
    }
}