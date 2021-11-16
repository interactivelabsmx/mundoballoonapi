using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Requests;
using MundoBalloonApi.infrastructure.Data.Models;
using Product = MundoBalloonApi.business.DataObjects.Entities.Product;
using ProductVariant = MundoBalloonApi.business.DataObjects.Entities.ProductVariant;

namespace MundoBalloonApi.business.Services;

public class ProductService : IProductService
{
    private readonly IDbContextFactory<MundoBalloonContext> _contextFactory;
    private readonly IMapper _mapper;

    public ProductService(IDbContextFactory<MundoBalloonContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
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
        var context = _contextFactory.CreateDbContext();
        context.Products.Add(product);
        context.SaveChanges();
        var productDto = _mapper.Map<Product>(product);
        return productDto;
    }

    public ProductVariant CreateProductVariant(CreateProductVariantRequest request)
    {
        var productVariant = new infrastructure.Data.Models.ProductVariant
        {
            Sku = request.Sku,
            ProductId = request.ProductId,
            ProductVariantName = request.Name,
            ProductVariantDescription = request.Description,
            Price = request.Price,
            CompareAtPrice = request.CompareAtPrice ?? 0,
            Weight = request.Weight ?? 0,
            Taxable = request.Taxable ?? false,
            StoreOnly = request.StoreOnly ?? false,
            IsBundle = request.IsBundle ?? false
        };
        var context = _contextFactory.CreateDbContext();
        context.ProductVariants.Add(productVariant);
        context.SaveChanges();
        var productVariantDto = _mapper.Map<ProductVariant>(productVariant);
        return productVariantDto;
    }
}