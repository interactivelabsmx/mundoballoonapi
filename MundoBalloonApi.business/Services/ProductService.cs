using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Contracts;

namespace MundoBalloonApi.business.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepository;

    public ProductService(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public Product CreateProduct(Product createProductRequest)
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

    public ProductVariant CreateProductVariant(ProductVariant request)
    {
        var productVariant = new infrastructure.Data.Models.ProductVariant
        {
            Sku = request.Sku,
            ProductId = request.ProductId,
            ProductVariantName = request.Name,
            ProductVariantDescription = request.Description,
            Price = request.Price
        };
        productVariant = _productsRepository.CreateProductVariant(productVariant);
        var productVariantDto = _mapper.Map<ProductVariant>(productVariant);
        return productVariantDto;
    }

    public ProductVariant ProductVariantAddValue(ProductVariantValue variantValue)
    {
        var variantValueModel = _mapper.Map<infrastructure.Data.Models.ProductVariantValue>(variantValue);
        var productVariant = _productsRepository.ProductVariantAddValue(variantValueModel);
        return _mapper.Map<ProductVariant>(productVariant);
    }

    public ProductVariant ProductVariantAddMedia(ProductVariantMedium variantMedia)
    {
        var variantMediaModel = _mapper.Map<infrastructure.Data.Models.ProductVariantMedium>(variantMedia);
        var productVariant = _productsRepository.ProductVariantAddMedia(variantMediaModel);
        return _mapper.Map<ProductVariant>(productVariant);
    }

    public bool DeleteProduct(int productId)
    {
        return _productsRepository.DeleteProduct(productId);
    }

    public bool DeleteProductVariant(int productVariantId)
    {
        return _productsRepository.DeleteProductVariant(productVariantId);
    }

    public Product UpdateProduct(ProductEntity productEntity)
    {
        var product = new infrastructure.Data.Models.Product
        {
            ProductId = productEntity.ProductId,
            ProductName = productEntity.Name,
            ProductDescription = productEntity.Description,
            Price = productEntity.Price,
            ProductCategoryId = productEntity.ProductCategoryId
        };
        var updatedProduct = _productsRepository.UpdateProduct(product);
        var productDto = _mapper.Map<Product>(updatedProduct);
        return productDto;
    }

    public ProductVariant UpdateProductVariant(ProductVariantEntity productVariantEntity)
    {
        var productVariant = new infrastructure.Data.Models.ProductVariant
        {
            ProductVariantId = productVariantEntity.ProductVariantId,
            Sku = productVariantEntity.Sku,
            ProductId = productVariantEntity.ProductId,
            ProductVariantName = productVariantEntity.Name,
            ProductVariantDescription = productVariantEntity.Description,
            Price = productVariantEntity.Price
        };
        var updateProductVariant = _productsRepository.UpdateProductVariant(productVariant);
        var productVariantDto = _mapper.Map<ProductVariant>(updateProductVariant);
        return productVariantDto;
    }
}