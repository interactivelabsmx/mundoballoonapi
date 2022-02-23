using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public bool? DeleteProductVariant(
        [Service] IProductService productService, int productVariantId)
    {
        return productService.DeleteProductVariant(productVariantId);
    }
}