using HotChocolate;
using HotChocolate.Execution;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.test.GraphQL.Fixtures;
using Snapshooter.Xunit;
using Xunit;

namespace MundoBalloonApi.test.GraphQL.Users;

[Collection("FirebaseInitializer")]
public class UserEventQueriesTest : BaseServiceCollection
{
    //GetUserEvents require CurrentUser
    //GetUserEventsById
    [Fact]
    public async Task GetUserEventsById_OK()
    {
        // Arrange
        var db = await ContextFactory?.CreateDbContextAsync()!;
        await using (db)
        {
            db.UserEvents.Add(new UserEvent
            {
                // This is an actual UserEventId
                UserEventId = 2,
                EventName = "Test"
            });
            await db.SaveChangesAsync();
        }

        // Act
        const string query = @"
          query GetUserEventById($userEventId: Int!) {
              userEventById(userEventId: $userEventId) {
                userEventId
                name
              }
            }
        ";
        var request = new QueryRequestBuilder().SetQuery(query)
            .SetVariableValue("userEventId", 2).Create();
        var result = await Executor?.ExecuteRequestAsync(request)!;
        // Assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
}