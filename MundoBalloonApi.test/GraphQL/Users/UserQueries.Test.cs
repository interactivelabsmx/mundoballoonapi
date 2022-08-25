using HotChocolate;
using HotChocolate.Execution;
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
            db.Users.Add(new User
            {
                // This is an actual firebase user
                UserId = "Mgq4doWHJNdRNmCVwz61XNOwKO92"
            });
            await db.SaveChangesAsync();
        }

        // Act
        const string query = @"
          query GetUserById($userId: String!) {
              userById(userId: $userId) {
                userId
              }
            }
        ";
        var request = new QueryRequestBuilder().SetQuery(query)
            .SetVariableValue("userId", "Mgq4doWHJNdRNmCVwz61XNOwKO92").Create();
        var result = await Executor?.ExecuteRequestAsync(request)!;
        // Assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
}