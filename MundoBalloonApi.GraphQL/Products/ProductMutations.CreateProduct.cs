using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<Product> CreateProduct(
        Product input,
        [Service] IProductService productService)
    {
        return productService.CreateProduct(input);
    }
}