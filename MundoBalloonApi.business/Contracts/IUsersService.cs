using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using MundoBalloonApi.business.DTOs.Requests;
using User = MundoBalloonApi.business.DTOs.Models.User;

namespace MundoBalloonApi.business.Contracts
{
    public interface IUsersService
    {
        User CreateOrGetUser(CreateUserRequest createUserRequest);
        Task<UserRecord?> GetFirebaseUserById(string userId);
    }
}