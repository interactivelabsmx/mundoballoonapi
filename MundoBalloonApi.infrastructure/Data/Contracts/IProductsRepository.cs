using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IProductsRepository
{
    IQueryable<Product> GetProducts();

    Product CreateProduct(Product product);

    bool DeleteProduct(int productId);

    bool DeleteProductVariant(int productVariantId);

    Product UpdateProduct(Product product);

    ProductVariant CreateProductVariant(ProductVariant productVariant);

    ProductVariant ProductVariantAddValue(ProductVariantValue variantValue);

    bool DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId);

    ProductVariant ProductVariantAddMedia(ProductVariantMedium variantMedia);

    bool DeleteProductVariantMedia(int productVariantMediaId);

    ProductVariant? GetProductVariantById(int productVariantId);

    ProductVariant UpdateProductVariant(ProductVariant productVariant);
}