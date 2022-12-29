using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.Contracts;

public interface ICollectionsService
{
    Task<ProductCategory> CreateProductCategory(ProductCategory productCategory, CancellationToken cancellationToken);

    Task<Variant> CreateVariant(Variant variant, CancellationToken cancellationToken);

    Task<VariantValue> CreateVariantValue(VariantValue variantValue, CancellationToken cancellationToken);

    Task<VariantsType> CreateVariantsType(string variantsType, CancellationToken cancellationToken);
}