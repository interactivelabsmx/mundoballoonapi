using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests.Products;

namespace MundoBalloonApi.business.Contracts;

public interface IProductService
{
    Product CreateProduct(CreateProductRequest createProductRequest);
    ProductVariant CreateProductVariant(CreateProductVariantRequest request);

    bool DeleteProduct(int productId);

    bool DeleteProductVariant(int productVariantId);

    Product UpdateProduct(ProductEntity productEntity);

    ProductVariant UpdateProductVariant(ProductVariantEntity productVariantEntity);
}