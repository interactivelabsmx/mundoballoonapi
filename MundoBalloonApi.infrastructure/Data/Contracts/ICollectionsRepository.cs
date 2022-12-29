using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface ICollectionsRepository
{
    Task<ProductCategory> CreateProductCategory(ProductCategory productCategory, CancellationToken cancellationToken);

    Task<Variant> CreateVariant(Variant variant, CancellationToken cancellationToken);

    Task<VariantValue> CreateVariantValue(VariantValue variant, CancellationToken cancellationToken);

    Task<VariantsType> CreateVariantsType(VariantsType variantsType, CancellationToken cancellationToken);
}