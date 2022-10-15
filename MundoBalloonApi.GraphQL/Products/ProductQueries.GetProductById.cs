using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DTOs.Entities.Product;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public async Task<Product?> GetProductById([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper, int productId)
    {
        var productQuery = await (
                from product in mundoBalloonContext.Products
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
                select product
            )
            .AsSplitQuery()
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return mapper.Map<Product>(productQuery);
    }
}