using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductCategory = MundoBalloonApi.business.DTOs.Entities.ProductCategory;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [AllowAnonymous]
    
    public IQueryable<ProductCategory> GetProductCategories(MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<ProductCategory>(mundoBalloonContext.ProductCategories);
    }
}