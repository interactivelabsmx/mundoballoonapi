using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface IUsersService
{
    Task<User> CreateOrGetUser(string userId, CancellationToken cancellationToken);
    Task<bool> DeleteUser(string userId, CancellationToken cancellationToken);
    Task<UserEvent> CreateUserEvent(string UserId, string Name, string details, CancellationToken cancellationToken);
    Task<bool> DeleteUserEvent(string userId, int userEventId, CancellationToken cancellationToken);
    Task<UserEvent> UpdateUserEvent(UserEvent userEvent, CancellationToken cancellationToken);
    Task<EventCartDetail> AddToEventCart(int productVariantId, int userEventId, double quantity, CancellationToken cancellationToken);
    Task<UserCart> AddToCart(string userId, string sku, double quantity, double price, int productVariantId, CancellationToken cancellationToken);
}