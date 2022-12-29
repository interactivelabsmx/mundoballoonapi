using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly IDbContextFactory<MundoBalloonContext> _contextFactory;

    public UsersRepository(IDbContextFactory<MundoBalloonContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<User> Create(User user, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Add(user);
            await context.SaveChangesAsync(cancellationToken);
        }

        return user;
    }

    public async Task<EventCartDetail> AddToEventCart(EventCartDetail eventCartDetail,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Add(eventCartDetail);
            await context.SaveChangesAsync(cancellationToken);
        }

        return eventCartDetail;
    }

    public async Task<UserCart> AddToCart(UserCart userCart, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            var alreadyOnCart = await context.UserCarts
                .Where(uc => uc.UserId == userCart.UserId && uc.ProductVariantId == userCart.ProductVariantId)
                .FirstOrDefaultAsync(cancellationToken);
            if (alreadyOnCart != null)
            {
                alreadyOnCart.Quantity += 1;
                context.UserCarts.Update(alreadyOnCart);
            }
            else
            {
                context.Add(userCart);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        return userCart;
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

    public async Task<OrderProductsDetails> AddOrderProductDetails(OrderProductsDetails orderProductsDetails,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Add(orderProductsDetails);
            await context.SaveChangesAsync(cancellationToken);
        }

        return orderProductsDetails;
    }

    public async Task<UserAddresses> AddUserAddresses(UserAddresses userAddresses, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Add(userAddresses);
            await context.SaveChangesAsync(cancellationToken);
        }

        return userAddresses;
    }

    public async Task<UserProfile> AddUserProfile(UserProfile userProfile, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Add(userProfile);
            await context.SaveChangesAsync(cancellationToken);
        }

        return userProfile;
    }


    public async Task<bool> DeleteUser(string userId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
        if (user == null) return false;
        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<User?> GetById(string userId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
        }
    }

    public async Task<UserEvent?> GetByUserId(int userEventId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.UserEvents.FirstOrDefaultAsync(ue => ue.UserEventId == userEventId, cancellationToken);
        }
    }

    public async Task<UserAddresses?> GetUserAddresses(string userId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.UserAddresses.FirstOrDefaultAsync(ue => ue.UserId == userId, cancellationToken);
        }
    }

    public async Task<UserProfile?> GetUserProfile(string userId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.UserProfiles.FirstOrDefaultAsync(ue => ue.UserId == userId, cancellationToken);
        }
    }

    public async Task<Orders?> GetOrders(string userId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.Orders.FirstOrDefaultAsync(ue => ue.UserId == userId, cancellationToken);
        }
    }

    public async Task<UserCart?> GetUserCarts(CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.UserCarts.FirstOrDefaultAsync(cancellationToken);
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

    public async Task<UserEvent> CreateUserEvent(UserEvent userEvent, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.Add(userEvent);
            await context.SaveChangesAsync(cancellationToken);
        }

        return userEvent;
    }

    public async Task<bool> DeleteUserEvent(int userEventId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var userEvent =
            await context.UserEvents.FirstOrDefaultAsync(ue => ue.UserEventId == userEventId, cancellationToken);
        if (userEvent == null) return false;
        context.UserEvents.Remove(userEvent);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteUserCartProduct(string sku, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var userCart =
            await context.UserCarts.FirstOrDefaultAsync(ue => ue.Sku == sku, cancellationToken);
        if (userCart == null) return false;
        context.UserCarts.Remove(userCart);
        await context.SaveChangesAsync(cancellationToken);
        return true;
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

    public async Task<bool> DeleteUserAddress(string userId, int userAddressesId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var userAddresses =
            await context.UserAddresses.FirstOrDefaultAsync(
                u => u.UserAddressesId == userAddressesId && u.UserId == userId,
                cancellationToken);
        if (userAddresses == null) return false;
        context.UserAddresses.Remove(userAddresses);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteUserProfile(string userId, int userProfileId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var userProfile =
            await context.UserProfiles.FirstOrDefaultAsync(u => u.UserProfileId == userProfileId && u.UserId == userId,
                cancellationToken);
        if (userProfile == null) return false;
        context.UserProfiles.Remove(userProfile);
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

    public async Task<UserEvent> UpdateUserEvent(UserEvent userEvent, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.UserEvents.Update(userEvent);
            await context.SaveChangesAsync(cancellationToken);
        }

        return userEvent;
    }

    public async Task<UserProfile> UpdateUserProfile(UserProfile userProfile, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.UserProfiles.Update(userProfile);
            await context.SaveChangesAsync(cancellationToken);
        }

        return userProfile;
    }

    public async Task<UserAddresses> UpdateUserAddresses(UserAddresses userAddresses,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            context.UserAddresses.Update(userAddresses);
            await context.SaveChangesAsync(cancellationToken);
        }

        return userAddresses;
    }
}