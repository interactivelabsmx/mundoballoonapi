using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.graphql.Products.Requests;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public UpdateProductPayload UpdateProduct(ProductEntity input, [Service] IProductService productService)
    {
        var product = productService.UpdateProduct(input);
        return new UpdateProductPayload(product);
    }
}