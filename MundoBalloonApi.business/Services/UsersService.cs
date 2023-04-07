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

    public async Task<UserEvent> CreateUserEvent(string userId, string name, string details, DateTime date,
        CancellationToken cancellationToken)
    {
        var userEvent = new infrastructure.Data.Models.UserEvent
        {
            UserId = userId,
            EventName = name,
            EventDate = date,
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

    public async Task<UserCartProduct> AddToCart(string userId, string sku, double quantity, double price,
        int productVariantId,
        CancellationToken cancellationToken)
    {
        var userCartProduct = new infrastructure.Data.Models.UserCartProduct
        {
            UserId = userId,
            Sku = sku,
            Quantity = quantity,
            Price = price,
            ProductVariantId = productVariantId
        };
        var cartProduct = await _usersRepository.AddToCart(userCartProduct, cancellationToken);
        return _mapper.Map<UserCartProduct>(cartProduct);
    }

    public async Task<UserCartProduct?> AddItemToCart(string userId, string sku, CancellationToken cancellationToken)
    {
        var cartProduct = await _usersRepository.AddItemToCart(userId, sku, cancellationToken);
        return _mapper.Map<UserCartProduct>(cartProduct);
    }

    public Task<bool> DeleteUserCartProduct(string userId, string sku, CancellationToken cancellationToken)
    {
        return _usersRepository.DeleteUserCartProduct(userId, sku, cancellationToken);
    }

    public async Task<UserCartProduct?> SubtractItemToCart(string userId, string sku,
        CancellationToken cancellationToken)
    {
        var cartProduct = await _usersRepository.AddItemToCart(userId, sku, cancellationToken);
        return _mapper.Map<UserCartProduct>(cartProduct);
    }
}