using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
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

    public async Task<Product> CreateProduct(Product createProductRequest, CancellationToken cancellationToken)
    {
        var product = new infrastructure.Data.Models.Product
        {
            ProductName = createProductRequest.Name,
            ProductDescription = createProductRequest.Description,
            Price = createProductRequest.Price,
            ProductCategoryId = createProductRequest.ProductCategoryId
        };
        product = await _productsRepository.CreateProduct(product, cancellationToken);
        return _mapper.Map<Product>(product);
    }

    public async Task<ProductVariant> CreateProductVariant(ProductVariant request, CancellationToken cancellationToken)
    {
        var productVariant = new infrastructure.Data.Models.ProductVariant
        {
            Sku = request.Sku,
            ProductId = request.ProductId,
            ProductVariantName = request.Name,
            ProductVariantDescription = request.Description,
            Price = request.Price
        };
        productVariant = await _productsRepository.CreateProductVariant(productVariant, cancellationToken);
        return _mapper.Map<ProductVariant>(productVariant);
    }

    public async Task<ProductVariant> ProductVariantAddValue(ProductVariantValue variantValue,
        CancellationToken cancellationToken)
    {
        var variantValueModel = new infrastructure.Data.Models.ProductVariantValue
        {
            ProductVariantId = variantValue.ProductVariantId,
            VariantId = variantValue.VariantId,
            VariantValueId = variantValue.VariantValueId
        };
        var productVariant = await _productsRepository.ProductVariantAddValue(variantValueModel, cancellationToken);
        return _mapper.Map<ProductVariant>(productVariant);
    }
    public async Task<bool> DeleteProductVariantValue(int productVariantId, int variantId, int variantValueId,
        CancellationToken cancellationToken)
    {
        return await _productsRepository.DeleteProductVariantValue(productVariantId, variantId, variantValueId,
            cancellationToken);
    }

    public async Task<ProductVariant> ProductVariantAddMedia(ProductVariantMedium variantMedia,
        CancellationToken cancellationToken)
    {
        var variantMediaModel = new infrastructure.Data.Models.ProductVariantMedium
        {
            ProductVariantId = variantMedia.ProductVariantId,
            MediaType = variantMedia.MediaType,
            Url = variantMedia.Url ?? "",
            Quality = variantMedia.Quality,
            Name = variantMedia.Name,
            Description = variantMedia.Description
        };
        var productVariant = await _productsRepository.ProductVariantAddMedia(variantMediaModel, cancellationToken);
        return _mapper.Map<ProductVariant>(productVariant);
    }

    public async Task<ProductVariantReview> AddProductVariantReview(int productVariantId, string userId, int rating, string comments,
        CancellationToken cancellationToken)
    {
        var reviewModel = new infrastructure.Data.Models.ProductVariantReview
        {
            ProductVariantId = productVariantId,
            UserId = userId,
            Rating = rating,
            Comments = comments
        };
        var productReview = await _productsRepository.AddProductVariantReview(reviewModel, cancellationToken);
        return _mapper.Map<ProductVariantReview>(productReview);
    }

    public async Task<bool> DeleteProductVariantMedia(int productVariantMediaId, CancellationToken cancellationToken)
    {
        return await _productsRepository.DeleteProductVariantMedia(productVariantMediaId, cancellationToken);
    }

    public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
    {
        return await _productsRepository.DeleteProduct(productId, cancellationToken);
    }

    public async Task<bool> DeleteProductVariant(int productVariantId, CancellationToken cancellationToken)
    {
        return await _productsRepository.DeleteProductVariant(productVariantId, cancellationToken);
    }

    public async Task<Product> UpdateProduct(ProductEntity productEntity, CancellationToken cancellationToken)
    {
        var product = new infrastructure.Data.Models.Product
        {
            ProductId = productEntity.ProductId,
            ProductName = productEntity.Name,
            ProductDescription = productEntity.Description,
            Price = productEntity.Price,
            ProductCategoryId = productEntity.ProductCategoryId
        };
        var updatedProduct = await _productsRepository.UpdateProduct(product, cancellationToken);
        return _mapper.Map<Product>(updatedProduct);
    }

    public async Task<ProductVariant> UpdateProductVariant(ProductVariantEntity productVariantEntity,
        CancellationToken cancellationToken)
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
        var updateProductVariant = await _productsRepository.UpdateProductVariant(productVariant, cancellationToken);
        return _mapper.Map<ProductVariant>(updateProductVariant);
    }
}