using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IUsersRepository
{
    Task<User?> GetById(string userId, CancellationToken cancellationToken);
    Task<User> Create(User user, CancellationToken cancellationToken);
    Task<bool> DeleteUser(string userId, CancellationToken cancellationToken);
    Task<UserEvent?> GetByUserId(int userEventId, CancellationToken cancellationToken);
    Task<UserEvent> CreateUserEvent(UserEvent userEvent, CancellationToken cancellationToken);
    Task<bool> DeleteUserEvent(int userEventId, CancellationToken cancellationToken);
    Task<UserEvent> UpdateUserEvent(UserEvent userEvent, CancellationToken cancellationToken);
    Task<EventCartDetail> AddToEventCart(EventCartDetail eventCartDetail, CancellationToken cancellationToken);
    Task<UserCart> AddToCart(UserCart userCart, CancellationToken cancellationToken);
    Task<bool> DeleteUserCartProduct(string sku, CancellationToken cancellationToken);
    Task<UserAddresses?> GetUserAddresses(string userId, CancellationToken cancellationToken);
    Task<UserProfile?> GetUserProfile(string userId, CancellationToken cancellationToken);
    Task<Orders?> GetOrders(string userId, CancellationToken cancellationToken);
    Task<UserCart?> GetUserCarts(CancellationToken cancellationToken);
    Task<OrderProductsDetails?> GetOrderProductsDetails(int orderId, CancellationToken cancellationToken);
    Task<Orders> AddOrder(Orders order, CancellationToken cancellationToken);

    Task<OrderProductsDetails> AddOrderProductDetails(OrderProductsDetails orderProductsDetails,
        CancellationToken cancellationToken);

    Task<UserAddresses> AddUserAddresses(UserAddresses userAddresses, CancellationToken cancellationToken);
    Task<UserProfile> AddUserProfile(UserProfile userProfile, CancellationToken cancellationToken);
    Task<UserProfile> UpdateUserProfile(UserProfile userProfiles, CancellationToken cancellationToken);
    Task<UserAddresses> UpdateUserAddresses(UserAddresses userAddresses, CancellationToken cancellationToken);
    Task<bool> DeleteOrder(string userId, int orderId, CancellationToken cancellationToken);
    Task<bool> DeleteUserAddress(string userId, int userAddressesId, CancellationToken cancellationToken);
    Task<bool> DeleteUserProfile(string userId, int userProfileId, CancellationToken cancellationToken);
    Task<bool> DeleteOrderProductDetails(int orderDetailsProductId, CancellationToken cancellationToken);
}