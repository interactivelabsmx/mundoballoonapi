using HotChocolate.Types;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Types
{
    public class VariantType : ObjectType<Variant>
    {
        protected override void Configure(IObjectTypeDescriptor<Variant> descriptor)
        {
            descriptor.Field(v => v.Variant1).Name("variant");
            descriptor.Field(v => v.VariantType).Name("type");

            // Ignore fields that create loops
            descriptor.Field(v => v.VariantValues).Ignore();
        }
    }
}