using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface IProductsRepository
{
    IQueryable<Product> GetProducts();

    Product CreateProduct(Product product);

    bool DeleteProduct(int productId);

    ProductVariant CreateProductVariant(ProductVariant productVariant);
}