using HotChocolate;
using HotChocolate.Execution;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.test.GraphQL.Fixtures;
using Snapshooter.Xunit;
using Xunit;

namespace MundoBalloonApi.test.GraphQL.Users;

[Collection("FirebaseInitializer")]
public class UserCartQueriesTest : BaseServiceCollection
{
    //GetUserCart require CurrentUser
    //GetUserCartCount require CurrentUser
    //GetUserCartProducts require CurrentUser
}