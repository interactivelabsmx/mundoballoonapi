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
    public async Task<bool> DeleteUserCartProduct(string userId, string sku, CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteUserCartProduct(sku, cancellationToken);
    }
    public async Task<bool> DeleteOrder(string userId,int orderId, CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteOrder(orderId, cancellationToken);
    }
    public async Task<bool> DeleteUserAddresses(string userId,int userAddressesId, CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteUserAddress(userAddressesId, cancellationToken);
    }
    public async Task<bool> DeleteUserProfile(string userId,int userProfileId, CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteUserProfile(userProfileId, cancellationToken);
    }
    public async Task<bool> DeleteOrderProductDetails(string userId,int orderDetailsProductId, CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteOrderProductDetails(orderDetailsProductId, cancellationToken);
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
    public async Task<UserProfile> UpdateUserProfile(int userProfileId,string userId, string firstName, string lastName, int phoneNumber
    , CancellationToken cancellationToken)
    {
        var userProfiles = new infrastructure.Data.Models.UserProfile
        {
            UserId = userId,
            UserProfileId = userProfileId,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
        };
        var updateUserProfile = await _usersRepository.UpdateUserProfile(userProfiles, cancellationToken);
        return _mapper.Map<UserProfile>(updateUserProfile);
    }
    public async Task<UserAddresses> UpdateUserAddresses(int userAddressesId, string userId, string address1, string address2, string city, string state, string country, string zipCode, CancellationToken cancellationToken)
    {
        var userAddressess = new infrastructure.Data.Models.UserAddresses
        {
            UserAddressesId = userAddressesId,
            UserId = userId,
            Address1 = address1,
            Address2 = address2,
            City = city,
            State = state,
            Country = country,
            Zipcode = zipCode
        };
        var UpdateUserAddresses = await _usersRepository.UpdateUserAddresses(userAddressess, cancellationToken);
        return _mapper.Map<UserAddresses>(UpdateUserAddresses);
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
    public async Task<Orders> AddOrder(string userId, int userAddressesId, int userProfileId,
        CancellationToken cancellationToken)
    {
        var order = new infrastructure.Data.Models.Orders
        {
            UserId = userId,
            UserAddressesId = userAddressesId,
            UserProfileId = userProfileId
        };
        order = await _usersRepository.AddOrder(order, cancellationToken);
        return _mapper.Map<Orders>(order);
    }
    public async Task<OrderProductsDetails> AddOrderProductDetails(int orderId, int productVariantId, int amount, decimal price, CancellationToken cancellationToken)
    {
        var orderProductsDetails = new infrastructure.Data.Models.OrderProductsDetails
        {
            OrderId = orderId,
            ProductVariantId = productVariantId,
            Amount = amount,
            Price = price
        };
        orderProductsDetails = await _usersRepository.AddOrderProductDetails(orderProductsDetails, cancellationToken);
        return _mapper.Map<OrderProductsDetails>(orderProductsDetails);
    }
    public async Task<UserAddresses> AddUserAddresses(string userId, string address1, string address2, string city, string state, string country, string zipCode, CancellationToken cancellationToken)
    {
        var userAddresses = new infrastructure.Data.Models.UserAddresses
        {
            UserId = userId,
            Address1 = address1,
            Address2 = address2,
            City = city,
            State = state,
            Country = country,
            Zipcode = zipCode
        };
        userAddresses = await _usersRepository.AddUserAddresses(userAddresses, cancellationToken);
        return _mapper.Map<UserAddresses>(userAddresses);
    }
    public async Task<UserProfile> AddUserProfile(string userId, string firstName, string lastName, int phoneNumber, CancellationToken cancellationToken)
    {
        var userProfile = new infrastructure.Data.Models.UserProfile
        {
            UserId = userId,
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
        };
        userProfile = await _usersRepository.AddUserProfile(userProfile, cancellationToken);
        return _mapper.Map<UserProfile>(userProfile);
    }
}