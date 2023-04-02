using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IOrdersRepository
{
    Task<Orders> AddOrder(Orders orders, CancellationToken cancellationToken);

    Task<Orders?> GetOrders(string userId, CancellationToken cancellationToken);

    Task<OrderProductsDetails?> GetOrderProductsDetails(int orderId, CancellationToken cancellationToken);

    Task<bool> DeleteOrder(string userId, int orderId, CancellationToken cancellationToken);

    Task<bool> DeleteOrderProductDetails(int orderProductsDetailsId, CancellationToken cancellationToken);

    Task<IEnumerable<OrderProductsDetails>> AddOrderProductDetailsRange(
        IEnumerable<OrderProductsDetails> items,
        CancellationToken cancellationToken);
}