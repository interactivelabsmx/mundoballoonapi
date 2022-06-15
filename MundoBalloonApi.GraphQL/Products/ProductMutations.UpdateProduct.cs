using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public Task<Product> UpdateProduct(ProductEntity input, [Service] IProductService productService)
    {
        return productService.UpdateProduct(input);
    }
}