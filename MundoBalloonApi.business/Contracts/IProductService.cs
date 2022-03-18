using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface IProductService
{
    Product CreateProduct(Product createProductRequest);
    ProductVariant CreateProductVariant(ProductVariant request);

    bool DeleteProduct(int productId);

    bool DeleteProductVariant(int productVariantId);

    Product UpdateProduct(ProductEntity productEntity);

    ProductVariant UpdateProductVariant(ProductVariantEntity productVariantEntity);
}