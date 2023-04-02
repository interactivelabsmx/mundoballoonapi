using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly IDbContextFactory<MundoBalloonContext> _contextFactory;

    public OrdersRepository(IDbContextFactory<MundoBalloonContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<Orders> AddOrder(Orders orders, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Add(orders);
            await context.SaveChangesAsync(cancellationToken);
        }

        return orders;
    }

    public async Task<Orders?> GetOrders(string userId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.Orders.FirstOrDefaultAsync(ue => ue.UserId == userId, cancellationToken);
        }
    }

    public async Task<OrderProductsDetails?> GetOrderProductsDetails(int orderId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.OrderProductDetails.FirstOrDefaultAsync(ue => ue.OrderId == orderId,
                cancellationToken);
        }
    }

    public async Task<bool> DeleteOrder(string userId, int orderId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var order = await context.Orders.FirstOrDefaultAsync(u => u.OrderId == orderId && u.UserId == userId,
            cancellationToken);
        if (order == null) return false;
        context.Orders.Remove(order);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteOrderProductDetails(int orderProductsDetailsId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var orderProductsDetails =
            await context.OrderProductDetails.FirstOrDefaultAsync(
                u => u.OrderDetailsProductsId == orderProductsDetailsId, cancellationToken);
        if (orderProductsDetails == null) return false;
        context.OrderProductDetails.Remove(orderProductsDetails);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<OrderProductsDetails>> AddOrderProductDetailsRange(
        IEnumerable<OrderProductsDetails> items,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var addOrderProductDetailsRange = items as OrderProductsDetails[] ?? items.ToArray();
        await using (context)
        {
            await context.AddRangeAsync(addOrderProductDetailsRange, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        return addOrderProductDetailsRange;
    }
}