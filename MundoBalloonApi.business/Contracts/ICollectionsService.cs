using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests.Collections;

namespace MundoBalloonApi.business.Contracts;

public interface ICollectionsService
{
    ProductCategory CreateProductCategory(CreateProductCategoryRequest productCategory);
}