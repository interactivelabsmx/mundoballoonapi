using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.infrastructure.Data.Contracts;

namespace MundoBalloonApi.business.Services;

public class UsersService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<User> CreateOrGetUser(string userId, CancellationToken cancellationToken)
    {
        var currentUser = await _usersRepository.GetById(userId, cancellationToken);
        if (currentUser != null) return _mapper.Map<User>(currentUser);

        var user = new infrastructure.Data.Models.User
        {
            UserId = userId
        };
        var result = await _usersRepository.Create(user, cancellationToken);
        return _mapper.Map<User>(result);
    }

    public async Task<bool> DeleteUser(string userId, CancellationToken cancellationToken)
    {
        var currentUser = await _usersRepository.GetById(userId, cancellationToken);
        if (currentUser != null) return false;
        return await _usersRepository.DeleteUser(userId, cancellationToken);
    }

    public async Task<UserEvent> CreateUserEvent(string userId, string name, string details, DateTime date,
        CancellationToken cancellationToken)
    {
        var userEvent = new infrastructure.Data.Models.UserEvent
        {
            UserId = userId,
            EventName = name,
            EventDate = date,
            EventDetails = details
        };
        userEvent = await _usersRepository.CreateUserEvent(userEvent, cancellationToken);
        return _mapper.Map<UserEvent>(userEvent);
    }

    public async Task<bool> DeleteUserEvent(string userId, int userEventId, CancellationToken cancellationToken)
    {
        var currentUser = await _usersRepository.GetById(userId, cancellationToken);
        if (currentUser != null) return false;
        return await _usersRepository.DeleteUserEvent(userEventId, cancellationToken);
    }

    public async Task<bool> DeleteProductVariantReview(int productVariantReviewId, string userId,
        CancellationToken cancellationToken)
    {
        var currentUser = await _usersRepository.GetById(userId, cancellationToken);
        if (currentUser != null) return false;
        return await _usersRepository.DeleteProductVariantReview(productVariantReviewId, userId, cancellationToken);
    }

    public async Task<bool> DeleteUserCartProduct(string userId, string sku, CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteUserCartProduct(userId, sku, cancellationToken);
    }

    public async Task<bool> DeleteOrder(string userId, int orderId, CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteOrder(userId, orderId, cancellationToken);
    }

    public async Task<bool> DeleteOrderProductDetails(int orderDetailsProductId,
        CancellationToken cancellationToken)
    {
        return await _usersRepository.DeleteOrderProductDetails(orderDetailsProductId, cancellationToken);
    }

    public async Task<UserEvent> UpdateUserEvent(UserEvent userEvent, CancellationToken cancellationToken)
    {
        var userEvents = new infrastructure.Data.Models.UserEvent
        {
            UserEventId = userEvent.UserEventId,
            UserId = userEvent.UserId,
            EventName = userEvent.Name,
            EventDate = userEvent.Date,
            EventDetails = userEvent.Details
        };
        var updatedUserEvent = await _usersRepository.UpdateUserEvent(userEvents, cancellationToken);
        return _mapper.Map<UserEvent>(updatedUserEvent);
    }

    public async Task<ProductVariantReview> UpdateProductVariantReview(int productVariantId, int productVariantReviewId,
        string userId, int rating, string comments, CancellationToken cancellationToken)
    {
        var productVariantReview = new infrastructure.Data.Models.ProductVariantReview
        {
            ProductVariantId = productVariantId,
            ProductVariantReviewId = productVariantReviewId,
            Rating = rating,
            Comments = comments
        };
        var updateProductVariantReview =
            await _usersRepository.UpdateProductVariantReview(productVariantReview, cancellationToken);
        return _mapper.Map<ProductVariantReview>(updateProductVariantReview);
    }

    public async Task<EventCartDetail> AddToEventCart(int productVariantId, int userEventId, double quantity,
        CancellationToken cancellationToken)
    {
        var eventCartDetail = new infrastructure.Data.Models.EventCartDetail
        {
            ProductVariantId = productVariantId,
            UserEventId = userEventId,
            Quantity = quantity
        };
        eventCartDetail = await _usersRepository.AddToEventCart(eventCartDetail, cancellationToken);
        return _mapper.Map<EventCartDetail>(eventCartDetail);
    }

    public async Task<UserCartProduct> AddToCart(string userId, string sku, double quantity, double price,
        int productVariantId,
        CancellationToken cancellationToken)
    {
        var userCart = new infrastructure.Data.Models.UserCartProduct
        {
            UserId = userId,
            Sku = sku,
            Quantity = quantity,
            Price = price,
            ProductVariantId = productVariantId
        };
        userCart = await _usersRepository.AddToCart(userCart, cancellationToken);
        return _mapper.Map<UserCartProduct>(userCart);
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

    public async Task<OrderProductsDetails> AddOrderProductDetails(int orderId, int productVariantId, int amount,
        decimal price, CancellationToken cancellationToken)
    {
        var orderProductsDetails = new infrastructure.Data.Models.OrderProductsDetails
        {
            OrderId = orderId,
            ProductVariantId = productVariantId,
            Amount = amount,
            Price = price
        };
        orderProductsDetails = await _usersRepository.AddOrderProductDetails(orderProductsDetails, cancellationToken);
        return _mapper.Map<OrderProductsDetails>(orderProductsDetails);
    }

    public async Task<IEnumerable<OrderProductsDetails>> AddOrderProductDetailsRange(Orders order,
        IEnumerable<OrderProductsDetails> productsDetails, CancellationToken cancellationToken)
    {
        if (order.OrderId == null) return productsDetails;
        var items = productsDetails.Select(item => new infrastructure.Data.Models.OrderProductsDetails
        {
            OrderId = (int)order.OrderId,
            ProductVariantId = item.ProductVariantId,
            Amount = item.Amount,
            Price = item.Price
        });
        var savedItems = await _usersRepository.AddOrderProductDetailsRange(items, cancellationToken);
        return _mapper.Map<IEnumerable<OrderProductsDetails>>(savedItems);
    }
}