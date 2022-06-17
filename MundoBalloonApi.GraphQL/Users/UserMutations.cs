using HotChocolate.AspNetCore.Authorization;
namespace MundoBalloonApi.graphql.Users;

[Authorize(Roles = new [] { "ADMIN" })]
[ExtendObjectType(Name = "Mutation")]
public partial class UserMutations
{
}