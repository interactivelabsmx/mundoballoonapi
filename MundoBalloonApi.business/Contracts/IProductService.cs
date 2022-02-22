using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests;
using MundoBalloonApi.business.DataObjects.Requests.Products;

namespace MundoBalloonApi.business.Contracts;

public interface IProductService
{
    Product CreateProduct(CreateProductRequest createProductRequest);
    ProductVariant CreateProductVariant(CreateProductVariantRequest request);

    bool DeleteProduct(int productId);

    Product UpdateProduct(UpdateProductRequest updateProductRequest);
    
}