using FirebaseAdmin.Auth;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests.Users;

namespace MundoBalloonApi.business.Contracts;

public interface IUsersService
{
    User CreateOrGetUser(CreateUserRequest createUserRequest);
    Task<UserRecord?> GetFirebaseUserById(string userId);
}