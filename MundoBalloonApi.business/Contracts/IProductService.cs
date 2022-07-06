using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface IProductService
{
    Task<Product> CreateProduct(Product createProductRequest);

    Task<ProductVariant> CreateProductVariant(ProductVariant request);

    Task<ProductVariant> ProductVariantAddValue(ProductVariantValue variantValue);

    Task<bool> DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId);

    Task<ProductVariant> ProductVariantAddMedia(ProductVariantMedium variantMedia);

    Task<bool> DeleteProductVariantMedia(int productVariantMediaId);

    Task<bool> DeleteProduct(int productId);

    Task<bool> DeleteProductVariant(int productVariantId);

    Task<Product> UpdateProduct(ProductEntity productEntity);

    Task<ProductVariant> UpdateProductVariant(ProductVariantEntity productVariantEntity);
}