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

    public async Task<Product> CreateProduct(Product createProductRequest)
    {
        var product = new infrastructure.Data.Models.Product
        {
            ProductName = createProductRequest.Name,
            ProductDescription = createProductRequest.Description,
            Price = createProductRequest.Price,
            ProductCategoryId = createProductRequest.ProductCategoryId
        };
        product = await _productsRepository.CreateProduct(product);
        return _mapper.Map<Product>(product);
    }

    public async Task<ProductVariant> CreateProductVariant(ProductVariant request)
    {
        var productVariant = new infrastructure.Data.Models.ProductVariant
        {
            Sku = request.Sku,
            ProductId = request.ProductId,
            ProductVariantName = request.Name,
            ProductVariantDescription = request.Description,
            Price = request.Price
        };
        productVariant = await _productsRepository.CreateProductVariant(productVariant);
        return _mapper.Map<ProductVariant>(productVariant);
    }

    public async Task<ProductVariant> ProductVariantAddValue(ProductVariantValue variantValue)
    {
        var variantValueModel = new infrastructure.Data.Models.ProductVariantValue
        {
            ProductVariantId = variantValue.ProductVariantId,
            VariantId = variantValue.VariantId,
            VariantValueId = variantValue.VariantValueId
        };
        var productVariant = await _productsRepository.ProductVariantAddValue(variantValueModel);
        return _mapper.Map<ProductVariant>(productVariant);
    }

    public async Task<bool> DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId)
    {
        return await _productsRepository.DeleteProductVariantValue(productVariantId, variantId, variantValueId);
    }

    public async Task<ProductVariant> ProductVariantAddMedia(ProductVariantMedium variantMedia)
    {
        var variantMediaModel = new infrastructure.Data.Models.ProductVariantMedium
        {
            ProductVariantId = variantMedia.ProductVariantId,
            MediaType = variantMedia.MediaType,
            Url = variantMedia.Url,
            Quality = variantMedia.Quality,
            Name = variantMedia.Name,
            Description = variantMedia.Description
        };
        var productVariant = await _productsRepository.ProductVariantAddMedia(variantMediaModel);
        return _mapper.Map<ProductVariant>(productVariant);
    }

    public async Task<bool> DeleteProductVariantMedia(int productVariantMediaId)
    {
        return await _productsRepository.DeleteProductVariantMedia(productVariantMediaId);
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        return await _productsRepository.DeleteProduct(productId);
    }

    public async Task<bool> DeleteProductVariant(int productVariantId)
    {
        return await _productsRepository.DeleteProductVariant(productVariantId);
    }

    public async Task<Product> UpdateProduct(ProductEntity productEntity)
    {
        var product = new infrastructure.Data.Models.Product
        {
            ProductId = productEntity.ProductId,
            ProductName = productEntity.Name,
            ProductDescription = productEntity.Description,
            Price = productEntity.Price,
            ProductCategoryId = productEntity.ProductCategoryId
        };
        var updatedProduct = await _productsRepository.UpdateProduct(product);
        return _mapper.Map<Product>(updatedProduct);
    }

    public async Task<ProductVariant> UpdateProductVariant(ProductVariantEntity productVariantEntity)
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
        var updateProductVariant = await _productsRepository.UpdateProductVariant(productVariant);
        return _mapper.Map<ProductVariant>(updateProductVariant);
    }
}