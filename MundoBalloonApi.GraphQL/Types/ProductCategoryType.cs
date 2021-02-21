using HotChocolate.Types;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Types
{
    public class ProductCategoryType: ObjectType<ProductCategory>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductCategory> descriptor)
        {
            descriptor
                .Field(pc => pc.ProductCategoryDescription)
                .Name("description");
            descriptor
                .Field(pc => pc.ProductCategoryName)
                .Name("name");
            
            // Ignore fields that create loops
            descriptor
                .Field(pc => pc.Products)
                .Ignore();
        }
    }
}