using FirebaseAdmin.Auth;
using MundoBalloonApi.business.DataObjects.Entities;
using User = MundoBalloonApi.infrastructure.Data.Models.User;

namespace MundoBalloonApi.graphql.Users;

[ExtendObjectType(Name = "Query")]
public partial class UserQueries
{
    private static FirebaseUser GetFirebaseUser(User user)
    {
        var userRecord = FirebaseAuth.DefaultInstance.GetUserAsync(user.UserId);
        return new FirebaseUser
        {
            Id = user.Id,
            UserId = user.UserId,
            Email = userRecord.Result.Email,
            DisplayName = userRecord.Result.DisplayName,
            PhoneNumber = userRecord.Result.PhoneNumber
        };
    }
}