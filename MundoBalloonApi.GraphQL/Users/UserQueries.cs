using AutoMapper;
using FirebaseAdmin.Auth;
using MundoBalloonApi.business.DataObjects.Entities;
using User = MundoBalloonApi.infrastructure.Data.Models.User;

namespace MundoBalloonApi.graphql.Users;

[ExtendObjectType(Name = "Query")]
public partial class UserQueries
{
    private static FirebaseUser GetFirebaseUser(User user, IMapper mapper)
    {
        var userRecord = FirebaseAuth.DefaultInstance.GetUserAsync(user.UserId);
        var firebaseUser = mapper.Map<FirebaseUser>(user);
        firebaseUser.Email = userRecord.Result.Email;
        firebaseUser.DisplayName = userRecord.Result.DisplayName;
        firebaseUser.PhoneNumber = userRecord.Result.PhoneNumber;
        return firebaseUser;
    }
}