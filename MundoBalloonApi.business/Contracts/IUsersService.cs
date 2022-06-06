using FirebaseAdmin.Auth;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface IUsersService
{
    Task<User> CreateOrGetUser(string userId);
    Task<UserRecord?> GetFirebaseUserById(string userId);
}