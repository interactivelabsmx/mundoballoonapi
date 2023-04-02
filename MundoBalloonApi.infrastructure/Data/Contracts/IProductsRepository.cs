using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IProductsRepository
{
    IQueryable<Product> GetProducts();

    Task<Product> CreateProduct(Product product, CancellationToken cancellationToken);

    Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken);

    Task<bool> DeleteProductVariant(int productVariantId, CancellationToken cancellationToken);

    Task<Product> UpdateProduct(Product product, CancellationToken cancellationToken);

    Task<ProductVariant> CreateProductVariant(ProductVariant productVariant, CancellationToken cancellationToken);

    Task<ProductVariant> ProductVariantAddValue(ProductVariantValue variantValue, CancellationToken cancellationToken);

    Task<bool> DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId,
        CancellationToken cancellationToken);

    Task<ProductVariant> ProductVariantAddMedia(ProductVariantMedium variantMedia, CancellationToken cancellationToken);

    Task<bool> DeleteProductVariantMedia(int productVariantMediaId, CancellationToken cancellationToken);

    Task<ProductVariant> UpdateProductVariant(ProductVariant productVariant, CancellationToken cancellationToken);

    Task<ProductVariantReview> AddProductVariantReview(ProductVariantReview variantReview,
        CancellationToken cancellationToken);

    Task<ProductVariantReview> UpdateProductVariantReview(ProductVariantReview productVariantReview,
        CancellationToken cancellationToken);

    Task<bool> DeleteProductVariantReview(int productVariantReviewId, string userId,
        CancellationToken cancellationToken);

    Task<IQueryable<UserCartProduct>> GetUserCartProducts(string userId,
        CancellationToken cancellationToken);

    Task<bool> DeleteUserCartProducts(IEnumerable<UserCartProduct> entities,
        CancellationToken cancellationToken);
}