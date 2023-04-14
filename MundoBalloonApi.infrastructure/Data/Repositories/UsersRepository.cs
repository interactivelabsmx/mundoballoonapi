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

    public async Task<UserEventCartDetail> AddToEventCart(UserEventCartDetail eventCartDetail,
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

    public async Task<UserCartProduct> AddToCart(UserCartProduct userCart, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            var alreadyOnCart = await context.UserCartProducts
                .Where(uc => uc.UserId == userCart.UserId && uc.ProductVariantId == userCart.ProductVariantId)
                .FirstOrDefaultAsync(cancellationToken);
            if (alreadyOnCart != null)
            {
                alreadyOnCart.Quantity += 1;
                context.UserCartProducts.Update(alreadyOnCart);
            }
            else
            {
                context.Add(userCart);
            }

            await context.SaveChangesAsync(cancellationToken);
        }

        return userCart;
    }

    public async Task<UserCartProduct?> AddItemToCart(string userId, string sku, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            var cartProduct = await context.UserCartProducts
                .Where(uc => uc.Sku == sku && uc.UserId == userId)
                .FirstOrDefaultAsync(cancellationToken);
            if (cartProduct != null)
            {
                cartProduct.Quantity += 1;
                context.UserCartProducts.Update(cartProduct);
            }

            await context.SaveChangesAsync(cancellationToken);
            return cartProduct;
        }
    }

    public async Task<UserCartProduct?> SubtractItemToCart(string userId, string sku,
        CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            var cartProduct = await context.UserCartProducts
                .Where(uc => uc.Sku == sku && uc.UserId == userId)
                .FirstOrDefaultAsync(cancellationToken);
            if (cartProduct == null || cartProduct.Quantity <= 1) return cartProduct;
            cartProduct.Quantity -= 1;
            context.UserCartProducts.Update(cartProduct);
            await context.SaveChangesAsync(cancellationToken);
            return cartProduct;
        }
    }

    public async Task<bool> DeleteUserCartProduct(string userId, string sku, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var userCart =
            await context.UserCartProducts.FirstOrDefaultAsync(ue => ue.Sku == sku && ue.UserId == userId,
                cancellationToken);
        if (userCart == null) return false;
        context.UserCartProducts.Remove(userCart);
        await context.SaveChangesAsync(cancellationToken);
        return true;
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

    public async Task<UserCartProduct?> GetUserCarts(CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.UserCartProducts.FirstOrDefaultAsync(cancellationToken);
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
}