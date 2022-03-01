using AutoMapper;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.business.DataObjects.Requests.Collections;
using MundoBalloonApi.infrastructure.Data.Contracts;

namespace MundoBalloonApi.business.Services;

public class CollectionsService : ICollectionsService
{
    private readonly IMapper _mapper;
    private readonly ICollectionsRepository _collectionsRepository;

    public CollectionsService(ICollectionsRepository collectionsRepository, IMapper mapper)
    {
        _collectionsRepository = collectionsRepository;
        _mapper = mapper;
    }

    public ProductCategory CreateProductCategory(CreateProductCategoryRequest productCategory)
    {
        var category = _mapper.Map<infrastructure.Data.Models.ProductCategory>(productCategory);
        _collectionsRepository.CreateProductCategory(category);
        var newCategory = _mapper.Map<ProductCategory>(category);
        return newCategory;
    }
}