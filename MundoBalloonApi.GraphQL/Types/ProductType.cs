using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Types
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor
                .Field(p => p.ProductName)
                .Name("name");

            descriptor
                .Field(p => p.ProductDescription)
                .Name("description");

            descriptor
                .Field(p => p.ProductVariants)
                .ResolveWith<ProductVariantsResolvers>(p => p.GetProductVariants(default!, default!, default!))
                .UseDbContext<MundoBalloonContext>()
                .Name("variants");

            descriptor
                .Field(p => p.ProductCategory)
                .ResolveWith<ProductCategoryResolvers>(p => p.GetProductCategory(default!, default!, default!))
                .UseDbContext<MundoBalloonContext>()
                .Name("category");
        }

        private class ProductVariantsResolvers
        {
            public async Task<List<ProductVariant>> GetProductVariants(
                Product product,
                [ScopedService] MundoBalloonContext mundoBalloonContext,
                CancellationToken cancellationToken)
            {
                return await mundoBalloonContext.ProductVariants.Where(pv => pv.ProductId == product.ProductId)
                    .ToListAsync(cancellationToken);
            }
        }

        private class ProductCategoryResolvers
        {
            public async Task<ProductCategory> GetProductCategory(
                Product product,
                [ScopedService] MundoBalloonContext mundoBalloonContext,
                CancellationToken cancellationToken)
            {
                return await mundoBalloonContext.ProductCategories.Where(pc =>
                    pc.ProductCategoryId == product.ProductCategoryId).FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}