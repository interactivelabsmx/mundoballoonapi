using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Types
{
    public class VariantValueType : ObjectType<VariantValue>
    {
        protected override void Configure(IObjectTypeDescriptor<VariantValue> descriptor)
        {
            descriptor.Field(vv => vv.VariantValue1).Name("value");
            descriptor
                .Field(vv => vv.Variant)
                .ResolveWith<VariantResolvers>(vv => vv.GetVariant(default!, default!, default!))
                .UseDbContext<MundoBalloonContext>();
        }

        private class VariantResolvers
        {
            public async Task<Variant> GetVariant(
                VariantValue variantValue,
                [ScopedService] MundoBalloonContext mundoBalloonContext,
                CancellationToken cancellationToken)
            {
                return await mundoBalloonContext.Variants.Where(v => v.VariantId == variantValue.VariantId)
                    .FirstOrDefaultAsync();
            }
        }
    }
}