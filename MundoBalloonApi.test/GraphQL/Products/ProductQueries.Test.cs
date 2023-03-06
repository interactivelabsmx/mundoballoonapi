
using HotChocolate;
using HotChocolate.Execution;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.test.GraphQL.Fixtures;
using Snapshooter.Xunit;
using Xunit;

namespace MundoBalloonApi.test.GraphQL.Products;

[Collection("FirebaseInitializer")]
public class ProductQueriesTest : BaseServiceCollection
{
    [Fact]
    public async Task GetProductQuickView_OK()
    {
        // Act
        const string query = @"
          query GetProductQuickView($productId: Int!) {
            productQuickView(productId: $productId) {
                productId
              }
            }
        ";
        var request = new QueryRequestBuilder().SetQuery(query)
            .SetVariableValue("productId", 4).Create();
        var result = await Executor?.ExecuteRequestAsync(request)!;
        // Assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
    [Fact]
    public async Task GetProductVariantById_OK()
    {
        // Arrange
        var db = await ContextFactory?.CreateDbContextAsync()!;
        await using (db)
        {
            db.ProductVariants.Add(new ProductVariant
            {
                // This is an actual ProductVariantId and SKU
                ProductVariantId = 2,
                Sku = "A1A0001",
            });
            await db.SaveChangesAsync();
        }
        // Act
        const string query = @"
          query GetProductVariantById($productVariantId: Int!) {
            productVariantById(productVariantId: $productVariantId) {
                productVariantId
                sku
              }
            }
        ";
        var request = new QueryRequestBuilder().SetQuery(query)
            .SetVariableValue("productVariantId", 2).Create();
        var result = await Executor?.ExecuteRequestAsync(request)!;
        // Assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
    [Fact]
    public async Task GetProductVariantsEntityById_OK()
    {
        // Arrange
        var db = await ContextFactory?.CreateDbContextAsync()!;
        await using (db)
        {
            db.ProductVariants.Add(new ProductVariant
            {
                // This is an actual ProductVariantId and SKU
                ProductId = 2,
                Sku = "Test"
            });
            await db.SaveChangesAsync();
        }
        // Act
        const string query = @"
          query GetProductVariantsEntityById($productId: Int!) {
            productVariantsEntityById(productId: $productId) {
                productId
              }
            }
        ";
        var request = new QueryRequestBuilder().SetQuery(query)
            .SetVariableValue("productId", 2).Create();
        var result = await Executor?.ExecuteRequestAsync(request)!;
        // Assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
    [Fact]
    public async Task GetProductById_OK()
    {
        // Act
        const string query = @"
          query GetProductById($productId: Int!) {
              productById(productId: $productId) {
                productId
              }
            }
        ";
        var request = new QueryRequestBuilder().SetQuery(query)
            .SetVariableValue("productId", 3).Create();
        var result = await Executor?.ExecuteRequestAsync(request)!;
        // Assert
        (await result.ToJsonAsync()).MatchSnapshot();
    }
}