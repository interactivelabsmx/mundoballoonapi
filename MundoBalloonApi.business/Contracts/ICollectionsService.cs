using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface ICollectionsService
{
    Task<ProductCategory> CreateProductCategory(ProductCategory productCategory);

    Task<Variant> CreateVariant(Variant variant);

    Task<VariantValue> CreateVariantValue(VariantValue variantValue);

    Task<VariantsType> CreateVariantsType(string variantsType);
}