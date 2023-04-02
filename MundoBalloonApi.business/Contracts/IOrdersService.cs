using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface IOrdersService
{
    Task<Orders> AddOrder(string userId, string paymentId, CancellationToken cancellationToken);

    Task<bool> DeleteOrder(string userId, int orderId, CancellationToken cancellationToken);

    Task<IEnumerable<OrderProductsDetails>?> AddOrderProductDetailsRange(Orders order,
        IEnumerable<UserCartProduct> productsDetails,
        CancellationToken cancellationToken);

    Task<bool> DeleteOrderProductDetails(int orderDetailsProductId,
        CancellationToken cancellationToken);
}