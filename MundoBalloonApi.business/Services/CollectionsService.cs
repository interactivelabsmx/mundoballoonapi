using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Contracts;

namespace MundoBalloonApi.business.Services;

public class CollectionsService : ICollectionsService
{
    private readonly ICollectionsRepository _collectionsRepository;
    private readonly IMapper _mapper;

    public CollectionsService(ICollectionsRepository collectionsRepository, IMapper mapper)
    {
        _collectionsRepository = collectionsRepository;
        _mapper = mapper;
    }

    public ProductCategory CreateProductCategory(ProductCategory productCategory)
    {
        var category = new infrastructure.Data.Models.ProductCategory
        {
            ProductCategoryName = productCategory.Name,
            ProductCategoryDescription = productCategory.Description
        };
        _collectionsRepository.CreateProductCategory(category);
        return _mapper.Map<ProductCategory>(category);
    }

    public Variant CreateVariant(Variant variant)
    {
        var newVariant = new infrastructure.Data.Models.Variant
        {
            Variant1 = variant.Name,
            VariantType = variant.Type
        };
        _collectionsRepository.CreateVariant(newVariant);
        return _mapper.Map<Variant>(newVariant);
    }

    public VariantValue CreateVariantValue(VariantValue variantValue)
    {
        var newVariant = new infrastructure.Data.Models.VariantValue
        {
            VariantId = variantValue.VariantId,
            VariantValue1 = variantValue.Value
        };
        _collectionsRepository.CreateVariantValue(newVariant);
        return _mapper.Map<VariantValue>(newVariant);
    }
}