using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.graphql.Collections.Responses;
using MundoBalloonApi.infrastructure.Data.Models;
using Variant = MundoBalloonApi.business.DTOs.Entities.Variant;
using VariantValue = MundoBalloonApi.business.DTOs.Entities.VariantValue;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public ProductVariants GetProductVariants([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        var variantValues = (
                from p in mundoBalloonContext.Products
                where p.ProductId == productId
                join pv in mundoBalloonContext.ProductVariants on p.ProductId equals pv.ProductId
                join pvv in mundoBalloonContext.ProductVariantValues on pv.ProductVariantId equals pvv.ProductVariantId
                join vv in mundoBalloonContext.VariantValues on pvv.VariantValueId equals vv.VariantValueId
                select vv)
            .Distinct()
            .AsEnumerable();

        var variants = (
                from v in mundoBalloonContext.Variants
                join vv in variantValues on v.VariantId equals vv.VariantId
                select v)
            .Distinct()
            .Include(v => v.UiRegistry)
            .AsEnumerable();

        return new ProductVariants
        {
            Variants = mapper.Map<List<Variant>>(variants),
            VariantValues = mapper.Map<List<VariantValue>>(variantValues)
        };
    }
}