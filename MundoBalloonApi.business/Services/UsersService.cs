using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Requests;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;

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

        public UserProfile Create(CreateUserProfileRequest userProfileRequest)
        {
            var user = _mapper.Map<UserProfile>(userProfileRequest);
            var result = _repository.Create(user);
            return result;
        }

        public UserProfile Update(UpdateUserProfileRequest userProfileRequest)
        {
            var user = _mapper.Map<UserProfile>(userProfileRequest);
            var result = _repository.Update(user);
            return result;
        }
    }
}