﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<User?> GetById(string userId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
        }
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
    public async Task<EventCartDetail> AddToEventCart(EventCartDetail eventCartDetail, CancellationToken cancellationToken)
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
            context.Add(userCart);
            await context.SaveChangesAsync(cancellationToken);
        }

        return userCart;
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

    public async Task<UserEvent?> GetByUserId(int userEventId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        await using (context)
        {
            return await context.UserEvents.FirstOrDefaultAsync(ue => ue.UserEventId == userEventId, cancellationToken);
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