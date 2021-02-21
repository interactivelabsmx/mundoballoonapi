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
    public class ProductVariantType: ObjectType<ProductVariant>
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
                .ResolveWith<ProductVariantMediaResolvers>(pv => pv.GetProductVariantMedia(default!, default!, default!))
                .UseDbContext<MundoBalloonContext>()
                .Name("media");

            // Ignore fields that loop back to product and carts
            descriptor
                .Field(pv => pv.Product).Ignore();
            
            descriptor
                .Field(pv => pv.OcassionCartDetailProductVariants).Ignore();
            
            descriptor
                .Field(pv => pv.OcassionCartDetailSkuNavigations).Ignore();
            
            descriptor
                .Field(pv => pv.UserCartProductVariants).Ignore();
        
            descriptor
                .Field(pv => pv.UserCartSkuNavigations).Ignore();
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
    }
}