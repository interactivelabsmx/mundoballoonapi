using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.graphql.Common.Requests;

namespace MundoBalloonApi.graphql.Products.Requests
{
    public class CreateProductVariantPayload : ClientMutationBase
    {
        public CreateProductVariantPayload(ProductVariant productVariant)
        {
            ProductVariant = productVariant;
        }

        public ProductVariant ProductVariant { get; }
    }
}