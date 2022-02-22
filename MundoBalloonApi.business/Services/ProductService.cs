using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Requests;
using MundoBalloonApi.business.DataObjects.Requests.Products;
using MundoBalloonApi.infrastructure.Data.Contracts;
using Product = MundoBalloonApi.business.DataObjects.Entities.Product;
using ProductVariant = MundoBalloonApi.business.DataObjects.Entities.ProductVariant;

namespace MundoBalloonApi.business.Services;

public class ProductService : IProductService
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public Product CreateProduct(CreateProductRequest createProductRequest)
    {
        var product = new infrastructure.Data.Models.Product
        {
            ProductName = createProductRequest.Name,
            ProductDescription = createProductRequest.Description,
            Price = createProductRequest.Price,
            ProductCategoryId = createProductRequest.ProductCategoryId
        };
        product = _productsRepository.CreateProduct(product);
        var productDto = _mapper.Map<Product>(product);
        return productDto;
    }

    public ProductVariant CreateProductVariant(CreateProductVariantRequest request)
    {
        var productVariant = new infrastructure.Data.Models.ProductVariant
        {
            Sku = request.Sku,
            ProductId = request.ProductId,
            VariantValueId = request.VariantValueId,
            ProductVariantName = request.Name,
            ProductVariantDescription = request.Description,
            Price = request.Price,
            Weight = request.Weight ?? 0,
            StoreOnly = request.StoreOnly ?? false,
            IsBundle = request.IsBundle ?? false
        };
        productVariant = _productsRepository.CreateProductVariant(productVariant);
        var productVariantDto = _mapper.Map<ProductVariant>(productVariant);
        return productVariantDto;
    }

    public bool DeleteProduct(int productId)
    {
        return _productsRepository.DeleteProduct(productId);
    }

    public Product UpdateProduct(UpdateProductRequest updateProductRequest)
    {
        var product = new infrastructure.Data.Models.Product()
        {
            ProductId = updateProductRequest.ProductId,
            ProductName = updateProductRequest.Name,
            ProductDescription = updateProductRequest.Description,
            Price = updateProductRequest.Price,
            ProductCategoryId = updateProductRequest.ProductCategoryId,
        };
        var updatedProduct = _productsRepository.UpdateProduct(product);
        var productDto = _mapper.Map<Product>(updatedProduct);
        return productDto;
    }
}