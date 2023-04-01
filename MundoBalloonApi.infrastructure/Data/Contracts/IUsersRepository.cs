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
    Task<UserCartProduct> AddToCart(UserCartProduct userCart, CancellationToken cancellationToken);
    Task<bool> DeleteUserCartProduct(string userId, string sku, CancellationToken cancellationToken);
    Task<Orders?> GetOrders(string userId, CancellationToken cancellationToken);
    Task<UserCartProduct?> GetUserCarts(CancellationToken cancellationToken);
    Task<OrderProductsDetails?> GetOrderProductsDetails(int orderId, CancellationToken cancellationToken);
    Task<Orders> AddOrder(Orders order, CancellationToken cancellationToken);

    Task<OrderProductsDetails> AddOrderProductDetails(OrderProductsDetails orderProductsDetails,
        CancellationToken cancellationToken);

    Task<bool> DeleteOrder(string userId, int orderId, CancellationToken cancellationToken);
    Task<bool> DeleteOrderProductDetails(int orderDetailsProductId, CancellationToken cancellationToken);

    Task<IEnumerable<OrderProductsDetails>> AddOrderProductDetailsRange(IEnumerable<OrderProductsDetails> items,
        CancellationToken cancellationToken);

    Task<ProductVariantReview> UpdateProductVariantReview(ProductVariantReview productVariantReview,
        CancellationToken cancellationToken);

    Task<bool> DeleteProductVariantReview(int productVariantReviewId, string userId,
        CancellationToken cancellationToken);
}