using Microsoft.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Collections;

public partial class CollectionQueries
{
    [AllowAnonymous]
    [UseDbContext(typeof(MundoBalloonContext))]
    public IQueryable<CountryCode> GetCountryCodes([ScopedService] MundoBalloonContext mundoBalloonContext)
    {
        return mundoBalloonContext.CountryCodes.Where(cc => cc.Supported == true);
    }
}