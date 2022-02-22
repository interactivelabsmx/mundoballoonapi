using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IProductsRepository
{
    IQueryable<Product> GetProducts();

    Product CreateProduct(Product product);

    bool DeleteProduct(int productId);

    Product UpdateProduct(Product product);

    ProductVariant CreateProductVariant(ProductVariant productVariant);
}