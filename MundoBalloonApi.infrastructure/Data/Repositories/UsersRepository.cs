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

    public async Task<bool> DeleteUser(string userId, CancellationToken cancellationToken)
    {
        var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
        if (user == null) return false;
        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
    public async Task<UserEvent> CreateUserEvent(UserEvent userEvent)
    {
        var context = await _contextFactory.CreateDbContextAsync();
        await using (context)
        {
            context.UserEvents.Add(userEvent);
            await context.SaveChangesAsync();
        }

        return userEvent;
    }
}