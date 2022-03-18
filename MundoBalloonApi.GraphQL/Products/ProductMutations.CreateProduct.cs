using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public Product CreateProduct(
        Product input,
        [Service] IProductService productService)
    {
        var product = productService.CreateProduct(input);
        return product;
    }
}