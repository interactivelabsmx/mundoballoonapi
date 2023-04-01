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

    Task<EventCartDetail> AddToEventCart(int productVariantId, int userEventId, double quantity,
        CancellationToken cancellationToken);

    Task<UserCartProduct> AddToCart(string userId, string sku, double quantity, double price, int productVariantId,
        CancellationToken cancellationToken);

    Task<bool> DeleteUserCartProduct(string userId, string sku, CancellationToken cancellationToken);
    Task<Orders> AddOrder(string userId, string paymentId, CancellationToken cancellationToken);

    Task<OrderProductsDetails> AddOrderProductDetails(int orderId, int productVariantId, int amount, decimal price,
        CancellationToken cancellationToken);

    Task<bool> DeleteOrder(string userId, int orderId, CancellationToken cancellationToken);

    Task<bool> DeleteOrderProductDetails(int orderDetailsProductId, CancellationToken cancellationToken);

    Task<IEnumerable<OrderProductsDetails>> AddOrderProductDetailsRange(Orders order,
        IEnumerable<OrderProductsDetails> productsDetails, CancellationToken cancellationToken);

    Task<ProductVariantReview> UpdateProductVariantReview(int productVariantId, int productVariantReviewId,
        string userId, int rating, string comments, CancellationToken cancellationToken);

    Task<bool> DeleteProductVariantReview(int productVariantReviewId, string userId,
        CancellationToken cancellationToken);
}