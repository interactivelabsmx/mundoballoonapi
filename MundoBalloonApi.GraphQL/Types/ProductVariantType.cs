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
    public class ProductVariantType : ObjectType<ProductVariant>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductVariant> descriptor)
        {
            descriptor
                .Field(pv => pv.ProductVariantDescription)
                .Name("description");

            descriptor
                .Field(pv => pv.ProductVariantName)
                .Name("name");

            descriptor
                .Field(pv => pv.ProductVariantMedia)
                .ResolveWith<ProductVariantMediaResolvers>(
                    pv => pv.GetProductVariantMedia(default!, default!, default!))
                .UseDbContext<MundoBalloonContext>()
                .Name("media");

            descriptor
                .Field(pv => pv.VariantValue)
                .ResolveWith<VariantValueResolvers>(pv => pv.GetProductVariantValue(default!, default!, default!))
                .UseDbContext<MundoBalloonContext>();
        }

        private class ProductVariantMediaResolvers
        {
            public async Task<List<ProductVariantMedium>> GetProductVariantMedia(
                ProductVariant productVariant,
                [ScopedService] MundoBalloonContext mundoBalloonContext,
                CancellationToken cancellationToken)
            {
                return await mundoBalloonContext.ProductVariantMedia
                    .Where(pvm => pvm.ProductVariantId == productVariant.ProductVariantId)
                    .ToListAsync(cancellationToken);
            }
        }

        private class VariantValueResolvers
        {
            public async Task<VariantValue> GetProductVariantValue(
                ProductVariant productVariant,
                [ScopedService] MundoBalloonContext mundoBalloonContext,
                CancellationToken cancellationToken)
            {
                return await mundoBalloonContext.VariantValues
                    .Where(vv => vv.VariantValueId == productVariant.VariantValueId)
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }
    }
}