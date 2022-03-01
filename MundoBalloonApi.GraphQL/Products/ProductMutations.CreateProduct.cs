using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests.Products;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public Product CreateProduct(
        CreateProductRequest input,
        [Service] IProductService productService)
    {
        var product = productService.CreateProduct(input);
        return product;
    }
}