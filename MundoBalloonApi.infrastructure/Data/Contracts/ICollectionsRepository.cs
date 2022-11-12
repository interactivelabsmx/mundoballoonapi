using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface ICollectionsRepository
{
    Task<ProductCategory> CreateProductCategory(ProductCategory productCategory);

    Task<Variant> CreateVariant(Variant variant);

    Task<VariantValue> CreateVariantValue(VariantValue variant);

    Task<VariantsType> CreateVariantsType(VariantsType variantsType);
}