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
        var newCategory = _mapper.Map<ProductCategory>(category);
        return newCategory;
    }
}