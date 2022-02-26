using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products.Requests;

public class UpdateProductVariantPayload
{
    public UpdateProductVariantPayload(ProductVariant productVariant)
    {
        ProductVariant = productVariant;
    }

    public ProductVariant ProductVariant { get; }
}