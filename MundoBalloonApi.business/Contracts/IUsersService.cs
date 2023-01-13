using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface IUsersService
{
    Task<User> CreateOrGetUser(string userId, CancellationToken cancellationToken);
    Task<bool> DeleteUser(string userId, CancellationToken cancellationToken);

    Task<UserEvent> CreateUserEvent(string userId, string name, string details, CancellationToken cancellationToken);

    Task<bool> DeleteUserEvent(string userId, int userEventId, CancellationToken cancellationToken);

    Task<UserEvent> UpdateUserEvent(UserEvent userEvent, CancellationToken cancellationToken);

    Task<EventCartDetail> AddToEventCart(int productVariantId, int userEventId, double quantity,
        CancellationToken cancellationToken);

    Task<UserCart> AddToCart(string userId, string sku, double quantity, double price, int productVariantId,
        CancellationToken cancellationToken);

    Task<bool> DeleteUserCartProduct(string userId, string sku, CancellationToken cancellationToken);
    Task<Orders> AddOrder(string userId, int userAddressesId, int userProfileId, CancellationToken cancellationToken);

    Task<OrderProductsDetails> AddOrderProductDetails(int orderId, int productVariantId, int amount, decimal price,
        CancellationToken cancellationToken);

    Task<UserAddresses> AddUserAddresses(string userId, string address1, string address2, string city, string state,
        string country, string zipCode, CancellationToken cancellationToken);

    Task<UserProfile> AddUserProfile(string userId, string firstName, string lastName, int phoneNumber,
        CancellationToken cancellationToken);

    Task<UserProfile> UpdateUserProfile(string userId, int userProfileId, string firstName, string lastName,
        int phoneNumber, CancellationToken cancellationToken);

    Task<UserAddresses> UpdateUserAddresses(int userAddressesId, string userId, string address1, string address2,
        string city, string state, string country, string zipCode, CancellationToken cancellationToken);

    Task<bool> DeleteOrder(string userId, int orderId, CancellationToken cancellationToken);

    Task<bool> DeleteUserAddresses(string userId, int userAddressesId, CancellationToken cancellationToken);

    Task<bool> DeleteOrderProductDetails(int orderDetailsProductId, CancellationToken cancellationToken);

    Task<bool> DeleteUserProfile(string userId, int userProfileId, CancellationToken cancellationToken);

    Task<IEnumerable<OrderProductsDetails>> AddOrderProductDetailsRange(Orders order,
        IEnumerable<OrderProductsDetails> productsDetails, CancellationToken cancellationToken);
}