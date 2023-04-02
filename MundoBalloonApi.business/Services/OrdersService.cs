using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Contracts;

namespace MundoBalloonApi.business.Services;

public class OrdersService : IOrdersService
{
    private readonly IMapper _mapper;
    private readonly IOrdersRepository _usersRepository;

    public OrdersService(IOrdersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<Orders> AddOrder(string userId, string paymentId, CancellationToken cancellationToken)
    {
        var order = new infrastructure.Data.Models.Orders
        {
            UserId = userId,
            PaymentId = paymentId
        };
        order = await _usersRepository.AddOrder(order, cancellationToken);
        return _mapper.Map<Orders>(order);
    }

    public async Task<bool> DeleteOrder(string userId, int orderId, CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteOrder(userId, orderId, cancellationToken);
    }

    public async Task<IEnumerable<OrderProductsDetails>?> AddOrderProductDetailsRange(Orders order,
        IEnumerable<UserCartProduct> productsDetails, CancellationToken cancellationToken)
    {
        if (order.OrderId == null) return null;
        var items = productsDetails.Select(item => new infrastructure.Data.Models.OrderProductsDetails
        {
            OrderId = (int)order.OrderId,
            ProductVariantId = item.ProductVariantId,
            Quantity = item.Quantity,
            Price = item.Price
        });
        var savedItems = await _usersRepository.AddOrderProductDetailsRange(items, cancellationToken);
        return _mapper.Map<IEnumerable<OrderProductsDetails>>(savedItems);
    }

    public async Task<bool> DeleteOrderProductDetails(int orderDetailsProductId,
        CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteOrderProductDetails(orderDetailsProductId, cancellationToken);
    }
}