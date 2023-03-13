using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface IProductService
{
    Task<Product> CreateProduct(Product createProductRequest, CancellationToken cancellationToken);

    Task<ProductVariant> CreateProductVariant(ProductVariant request, CancellationToken cancellationToken);

    Task<ProductVariant> ProductVariantAddValue(ProductVariantValue variantValue, CancellationToken cancellationToken);

    Task<bool> DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId,
        CancellationToken cancellationToken);

    Task<ProductVariant> ProductVariantAddMedia(ProductVariantMedium variantMedia, CancellationToken cancellationToken);

    Task<ProductVariantReview> AddProductVariantReview(int productVariantId, string userId, int rating, string comments,
        CancellationToken cancellationToken);

    Task<bool> DeleteProductVariantMedia(int productVariantMediaId, CancellationToken cancellationToken);

    Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken);

    Task<bool> DeleteProductVariant(int productVariantId, CancellationToken cancellationToken);

    Task<Product> UpdateProduct(ProductEntity productEntity, CancellationToken cancellationToken);

    Task<ProductVariant> UpdateProductVariant(ProductVariantEntity productVariantEntity,
        CancellationToken cancellationToken);
}