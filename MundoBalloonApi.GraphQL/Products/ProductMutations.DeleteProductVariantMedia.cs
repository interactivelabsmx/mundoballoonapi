using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new [] { "ADMIN" })]
    public Task<bool> DeleteProductVariantMedia(
        [Service] IProductService productService, int productVariantMediaId)
    {
        return productService.DeleteProductVariantMedia(productVariantMediaId);
    }
}