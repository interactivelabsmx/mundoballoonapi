using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests.Products;
using MundoBalloonApi.graphql.Products.Requests;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public ProductVariant CreateProductVariant(
        CreateProductVariantRequest input,
        [Service] IProductService productService)
    {
        var productVariant = productService.CreateProductVariant(input);
        return productVariant;
    }
}