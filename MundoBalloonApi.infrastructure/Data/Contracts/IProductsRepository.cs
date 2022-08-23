using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IProductsRepository
{
    IQueryable<Product> GetProducts();

    Task<Product> CreateProduct(Product product);

    Task<bool> DeleteProduct(int productId);

    Task<bool> DeleteProductVariant(int productVariantId);

    Task<Product> UpdateProduct(Product product);

    Task<ProductVariant> CreateProductVariant(ProductVariant productVariant);

    Task<ProductVariant> ProductVariantAddValue(ProductVariantValue variantValue);

    Task<bool> DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId);

    Task<ProductVariant> ProductVariantAddMedia(ProductVariantMedium variantMedia);

    Task<bool> DeleteProductVariantMedia(int productVariantMediaId);

    Task<ProductVariant> UpdateProductVariant(ProductVariant productVariant);

    Task<ProductVariant> AddProductVariantReview(ProductVariantReview variantReview);
}