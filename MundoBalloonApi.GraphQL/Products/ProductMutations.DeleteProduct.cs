using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public bool? DeleteProduct(
        [Service] IProductService productService, int productId)
    {
        return productService.DeleteProduct(productId);
    }
}