using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public Task<Product> CreateProduct(
        Product input,
        [Service] IProductService productService)
    {
        return productService.CreateProduct(input);
    }
}