using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public Product UpdateProduct(ProductEntity input, [Service] IProductService productService)
    {
        var product = productService.UpdateProduct(input);
        return product;
    }
}