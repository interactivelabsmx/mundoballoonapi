using HotChocolate.Types;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Types
{
    public class ProductVariantMediumType : ObjectType<ProductVariantMedium>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductVariantMedium> descriptor)
        {
            // Ignore fields that create loops
            descriptor.Field(pvm => pvm.ProductVariant).Ignore();
        }
    }
}