using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests;

namespace MundoBalloonApi.business.Contracts
{
    public interface IUsersService
    {
        User CreateOrGetUser(CreateUserRequest createUserRequest);
        Task<UserRecord?> GetFirebaseUserById(string userId);
        List<UserClaim> GetUserClaims(string userId);
    }
}