using HotChocolate;
using HotChocolate.Execution;
using MundoBalloonApi.test.GraphQL.Fixtures;
using Snapshooter.Xunit;
using Xunit;

namespace MundoBalloonApi.test.GraphQL.Site;

[Collection("FirebaseInitializer")]
public class GetHomepageProductsTest : BaseServiceCollection
{
    [Fact]
    public async Task GetHomepageProductsTest_GetsFeaturedProducts()
    {
        // Act
        const string query = Fragments.ProductsDictionaryFragment + @"
            query GetHomepageProducts(
              $includeBestSelling: Boolean = false
              $includeNewest: Boolean = false
            ) {
              homepageProducts(
                includeBestSellingProducts: $includeBestSelling
                includeNewestProducts: $includeNewest
              ) {
                ...ProductsDictionary
              }
            }
        ";
        var request = new QueryRequestBuilder().SetQuery(query).SetVariableValue("userId", "1").Create();
        var result = await Executor?.ExecuteRequestAsync(request)!;
        // Assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
}