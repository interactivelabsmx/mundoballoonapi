using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Requests;
using MundoBalloonApi.graphql.Products.Requests;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    public CreateProductVariantPayload CreateProductVariant(
        CreateProductVariantRequest input,
        [Service] IProductService productService)
    {
        var product = productService.CreateProductVariant(input);
        return new CreateProductVariantPayload(product);
    }
}