using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MundoBalloonApi.business.Middleware;
using MundoBalloonApi.graphql.Users;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.test.GraphQL.Fixtures;
using Snapshooter.Xunit;
using Xunit;

namespace MundoBalloonApi.test.GraphQL.Users;

[Collection("FirebaseInitializer")]
public class UserQueriesTest : BaseServiceCollection
{
    [Fact]
    public async Task GetUserById_OK()
    {
        // Arrange
        var db = await ContextFactory?.CreateDbContextAsync()!;
        await using (db)
        {
            db?.Users.Add(new User
            {
                Id = 999,
                // This is an actual firebase user
                UserId = "Mgq4doWHJNdRNmCVwz61XNOwKO92"
            });
            await db?.SaveChangesAsync()!;
        }
        // Act
        var query = @"
          query GetUserById($userId: String!) {
              userById(userId: $userId) {
                id
              }
            }
        ";
        IReadOnlyQueryRequest request = new QueryRequestBuilder().SetQuery(query).SetVariableValue("userId", "Mgq4doWHJNdRNmCVwz61XNOwKO92").Create();
        var result = await Executor?.ExecuteRequestAsync(request)!;
        // Assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
}