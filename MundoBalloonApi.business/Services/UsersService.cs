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

    public async Task<UserEvent> CreateUserEvent(string userId, string name, string details,
        CancellationToken cancellationToken)
    {
        var userEvent = new infrastructure.Data.Models.UserEvent
        {
            UserId = userId,
            EventName = name,
            EventDetails = details
        };
        userEvent = await _usersRepository.CreateUserEvent(userEvent, cancellationToken);
        return _mapper.Map<UserEvent>(userEvent);
    }

    public async Task<bool> DeleteUserEvent(string userId, int userEventId, CancellationToken cancellationToken)
    {
        var currentUser = await _usersRepository.GetById(userId, cancellationToken);
        if (currentUser != null) return false;
        return await _usersRepository.DeleteUserEvent(userEventId, cancellationToken);
    }

    public async Task<UserEvent> UpdateUserEvent(UserEvent userEvent, CancellationToken cancellationToken)
    {
        var userEvents = new infrastructure.Data.Models.UserEvent
        {
            UserEventId = userEvent.UserEventId,
            UserId = userEvent.UserId,
            EventName = userEvent.Name,
            EventDate = userEvent.Date,
            EventDetails = userEvent.Details
        };
        var updatedUserEvent = await _usersRepository.UpdateUserEvent(userEvents, cancellationToken);
        return _mapper.Map<UserEvent>(updatedUserEvent);
    }
    public async Task<EventCartDetail> AddToEventCart(int productVariantId, int userEventId, double quantity,
        CancellationToken cancellationToken)
    {
        var eventCartDetail = new infrastructure.Data.Models.EventCartDetail
        {
            ProductVariantId = productVariantId,
            UserEventId = userEventId,
            Quantity = quantity
        };
        eventCartDetail = await _usersRepository.AddToEventCart(eventCartDetail, cancellationToken);
        return _mapper.Map<EventCartDetail>(eventCartDetail);
    }
    public async Task<UserCart> AddToCart(string userId, string sku, double quantity, double price, int productVariantId,
        CancellationToken cancellationToken)
    {
        var userCart = new infrastructure.Data.Models.UserCart
        {
            UserId = userId,
            Sku = sku,
            Quantity = quantity,
            Price = price,
            ProductVariantId = productVariantId
        };
        userCart = await _usersRepository.AddToCart(userCart, cancellationToken);
        return _mapper.Map<UserCart>(userCart);
    }
}