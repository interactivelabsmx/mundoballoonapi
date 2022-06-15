using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public Task<bool> DeleteProduct(
        [Service] IProductService productService, int productId) => productService.DeleteProduct(productId);
}