﻿using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IUsersRepository
{
    Task<User?> GetById(string userId, CancellationToken cancellationToken);

    Task<User> Create(User user, CancellationToken cancellationToken);

    Task<bool> DeleteUser(string userId, CancellationToken cancellationToken);
    Task<UserEvent?> GetByUserId(int UserEventId, CancellationToken cancellationToken);

    Task<UserEvent> CreateUserEvent(UserEvent userEvent, CancellationToken cancellationToken);
    Task<bool> DeleteUserEvent(int userEventId);
    Task<UserEvent> UpdateUserEvent (UserEvent userEvent);
}