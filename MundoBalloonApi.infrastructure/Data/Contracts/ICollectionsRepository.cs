using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.infrastructure.Data.Contracts;

public interface ICollectionsRepository
{
    ProductCategory CreateProductCategory(ProductCategory productCategory);
}