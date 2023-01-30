using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;
using CountryCode = MundoBalloonApi.business.DTOs.Entities.CountryCode;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [Authorize]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<CountryCode> GetCountryCodes([ScopedService] MundoBalloonContext mundoBalloonContext,
        [Service] IMapper mapper)
    {
        return mapper.ProjectTo<CountryCode>(mundoBalloonContext.CountryCodes.Where(cc => cc.Supported == true));
    }
}