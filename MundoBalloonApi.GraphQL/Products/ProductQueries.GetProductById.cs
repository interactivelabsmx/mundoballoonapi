using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DTOs.Entities.Product;
using VariantValue = MundoBalloonApi.business.DTOs.Entities.VariantValue;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public async Task<(Product?, IQueryable<VariantValue>)> GetProductById([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        var productQuery = await (from product in mundoBalloonContext.Products
                join productCategory in mundoBalloonContext.ProductCategories
                    on product.ProductCategoryId equals productCategory.ProductCategoryId
                join productVariant in mundoBalloonContext.ProductVariants
                    on product.ProductId equals productVariant.ProductId
                join medium in mundoBalloonContext.ProductVariantMedia
                    on productVariant.ProductVariantId equals medium.ProductVariantId
                join productVariantValue in mundoBalloonContext.ProductVariantValues
                    on productVariant.ProductVariantId equals productVariantValue.ProductVariantId
                join variantValue in mundoBalloonContext.VariantValues
                    on productVariantValue.VariantValueId equals variantValue.VariantValueId
                where product.ProductId == productId
                select product)
            .AsSplitQuery()
            .AsNoTracking()
            .FirstOrDefaultAsync();

        var variantQuery = (from pvv in mundoBalloonContext.ProductVariantValues
                join pv in mundoBalloonContext.ProductVariants on pvv.ProductVariantId equals pv.ProductVariantId
                join p in mundoBalloonContext.Products on pv.ProductId equals p.ProductId
                join v in mundoBalloonContext.Variants on pvv.VariantId equals v.VariantId
                join vv in mundoBalloonContext.VariantValues on pvv.VariantValueId equals vv.VariantValueId
                where pv.ProductId == productId
                select vv)
            .Include(vv => vv.Variant)
            .AsSplitQuery()
            .AsNoTracking();

        return (mapper.Map<Product>(productQuery), mapper.ProjectTo<VariantValue>(variantQuery));
    }
}