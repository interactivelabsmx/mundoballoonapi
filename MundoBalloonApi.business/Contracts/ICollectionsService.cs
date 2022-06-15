using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface ICollectionsService
{
    Task<ProductCategory> CreateProductCategory(ProductCategory productCategory);

    Task<Variant> CreateVariant(Variant variant);

    Task<VariantValue> CreateVariantValue(VariantValue variantValue);
}