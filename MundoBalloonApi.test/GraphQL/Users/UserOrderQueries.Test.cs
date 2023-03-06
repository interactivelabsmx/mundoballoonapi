using HotChocolate;
using HotChocolate.Execution;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.test.GraphQL.Fixtures;
using Snapshooter.Xunit;
using Xunit;

namespace MundoBalloonApi.test.GraphQL.Users;

[Collection("FirebaseInitializer")]
public class UserOrderQueriesTest : BaseServiceCollection
{
    //GetOrders require CurrentUser
    //GetOrderProductDetails
    [Fact]
    public async Task GetOrdersProductDetails_OK()
    {
        // Arrange
        var db = await ContextFactory?.CreateDbContextAsync()!;
        await using (db)
        {
            db.OrderProductDetails.Add(new OrderProductsDetails
            {
                // This is an actual OrderDetailsProductsId
                OrderDetailsProductsId = 1
            });
            await db.SaveChangesAsync();
        }

        // Act
        const string query = @"
          query GetOrdersProductDetails($orderDetailsProductsId: Int!) {
              ordersProductDetails(orderDetailsProductsId: $orderDetailsProductsId) {
                orderDetailsProductsId
              }
            }
        ";
        var request = new QueryRequestBuilder().SetQuery(query)
            .SetVariableValue("orderDetailsProductsId", 1).Create();
        var result = await Executor?.ExecuteRequestAsync(request)!;
        // Assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
}