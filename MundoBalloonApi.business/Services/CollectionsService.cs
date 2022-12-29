using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
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

    public async Task<ProductCategory> CreateProductCategory(ProductCategory productCategory,
        CancellationToken cancellationToken)
    {
        var category = new infrastructure.Data.Models.ProductCategory
        {
            ProductCategoryName = productCategory.Name,
            ProductCategoryDescription = productCategory.Description
        };
        await _collectionsRepository.CreateProductCategory(category, cancellationToken);
        return _mapper.Map<ProductCategory>(category);
    }

    public async Task<Variant> CreateVariant(Variant variant, CancellationToken cancellationToken)
    {
        var newVariant = new infrastructure.Data.Models.Variant
        {
            Variant1 = variant.Name,
            VariantTypeId = variant.VariantTypeId
        };
        await _collectionsRepository.CreateVariant(newVariant, cancellationToken);
        return _mapper.Map<Variant>(newVariant);
    }

    public async Task<VariantValue> CreateVariantValue(VariantValue variantValue, CancellationToken cancellationToken)
    {
        var newVariant = new infrastructure.Data.Models.VariantValue
        {
            VariantId = variantValue.VariantId,
            VariantValue1 = variantValue.Value
        };
        await _collectionsRepository.CreateVariantValue(newVariant, cancellationToken);
        return _mapper.Map<VariantValue>(newVariant);
    }

    public async Task<VariantsType> CreateVariantsType(string variantsType, CancellationToken cancellationToken)
    {
        var newVariantType = new infrastructure.Data.Models.VariantsType(variantsType);
        await _collectionsRepository.CreateVariantsType(newVariantType, cancellationToken);
        return _mapper.Map<VariantsType>(newVariantType);
    }
}