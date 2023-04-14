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
    Task<UserEventCartDetail> AddToEventCart(UserEventCartDetail eventCartDetail, CancellationToken cancellationToken);
    Task<UserCartProduct> AddToCart(UserCartProduct userCart, CancellationToken cancellationToken);
    Task<UserCartProduct?> AddItemToCart(string userId, string sku, CancellationToken cancellationToken);
    Task<UserCartProduct?> SubtractItemToCart(string userId, string sku, CancellationToken cancellationToken);
    Task<bool> DeleteUserCartProduct(string userId, string sku, CancellationToken cancellationToken);
    Task<UserCartProduct?> GetUserCarts(CancellationToken cancellationToken);
}