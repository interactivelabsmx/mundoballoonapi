using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<ProductVariant> UpdateProductVariant(ProductVariantEntity input,
        [Service] IProductService productService, CancellationToken cancellationToken)
    {
        return productService.UpdateProductVariant(input, cancellationToken);
    }
}