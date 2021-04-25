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

        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public User Create(CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<infrastructure.Data.Models.User>(createUserRequest);
            var result = _repository.Create(user);
            return _mapper.Map<User>(result);
        }
    }
}