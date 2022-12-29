using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public Task<Product> UpdateProduct(ProductEntity input, [Service] IProductService productService,
        CancellationToken cancellationToken)
    {
        return productService.UpdateProduct(input, cancellationToken);
    }
}