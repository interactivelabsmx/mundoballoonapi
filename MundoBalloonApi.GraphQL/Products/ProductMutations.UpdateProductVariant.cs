using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.graphql.Products.Requests;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public ProductVariant UpdateProductVariant(ProductVariantEntity input,
        [Service] IProductService productService)
    {
        var productVariant = productService.UpdateProductVariant(input);
        return productVariant;
    }
}