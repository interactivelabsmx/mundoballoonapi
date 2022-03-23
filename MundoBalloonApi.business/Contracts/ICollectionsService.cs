using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface ICollectionsService
{
    ProductCategory CreateProductCategory(ProductCategory productCategory);

    Variant CreateVariant(Variant variant);
    
    VariantValue CreateVariantValue(VariantValue variantValue);
}