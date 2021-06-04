using System.Collections.Generic;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts
{
    public interface IUsersRepository
    {
        User? GetById(string userId);

        User Create(User user);

        List<UserClaim> GetUserClaims(string userId);
    }
}