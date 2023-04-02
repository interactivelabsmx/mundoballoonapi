using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface IUsersService
{
    Task<User> CreateOrGetUser(string userId, CancellationToken cancellationToken);
    Task<bool> DeleteUser(string userId, CancellationToken cancellationToken);

    Task<UserEvent> CreateUserEvent(string userId, string name, string details, DateTime date,
        CancellationToken cancellationToken);

    Task<bool> DeleteUserEvent(string userId, int userEventId, CancellationToken cancellationToken);

    Task<UserEvent> UpdateUserEvent(UserEvent userEvent, CancellationToken cancellationToken);

    Task<EventCartDetail> AddToEventCart(int productVariantId, int userEventId, decimal quantity,
        CancellationToken cancellationToken);

    Task<UserCartProduct> AddToCart(string userId, string sku, decimal quantity, decimal price, int productVariantId,
        CancellationToken cancellationToken);

    Task<bool> DeleteUserCartProduct(string userId, string sku, CancellationToken cancellationToken);
}