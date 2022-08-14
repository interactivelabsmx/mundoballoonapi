using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Contracts;

namespace MundoBalloonApi.business.Services;

public class UsersService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<User> CreateOrGetUser(string userId, CancellationToken cancellationToken)
    {
        var currentUser = await _usersRepository.GetById(userId, cancellationToken);
        if (currentUser != null) return _mapper.Map<User>(currentUser);

        var user = new infrastructure.Data.Models.User
        {
            UserId = userId
        };
        var result = await _usersRepository.Create(user, cancellationToken);
        return _mapper.Map<User>(result);
    }

    public async Task<bool> DeleteUser(string userId, CancellationToken cancellationToken)
    {
        var currentUser = await _usersRepository.GetById(userId, cancellationToken);
        if (currentUser != null) return false;
        return await _usersRepository.DeleteUser(userId, cancellationToken);
    }
}