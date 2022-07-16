using HotChocolate;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MundoBalloonApi.graphql.Users;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.test.Fixtures;
using Snapshooter.Xunit;
using Xunit;

namespace MundoBalloonApi.test.GraphQL.Users;

public class UserQueriesTest
{
    [Fact]
    public async Task CreateUser()
    {
        // arrange
        var executor = await new ServiceCollection()
            .AddPooledDbContextFactory<MundoBalloonContext>(
                options => options.UseInMemoryDatabase("MundoBalloonContext:Integration:Graphql"))
            .AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<UserQueries>()
            .BuildRequestExecutorAsync();
        // act
        var fakeData = new FakeData();
        var db = executor.Services.GetService<MundoBalloonContext>();
        await using (db)
        {
            db?.Users.AddRange(fakeData.Users);
            await db?.SaveChangesAsync()!;
        }

        var result = await executor.ExecuteAsync(@"
          userById(userId: 2) {
            ...User
          }
        ");

        // assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
}