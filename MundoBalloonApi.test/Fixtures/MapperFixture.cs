using AutoMapper;
using MundoBalloonApi.business.Middleware;

namespace MundoBalloonApi.test.Fixtures;

public class MapperFixture : IDisposable
{
    public MapperFixture()
    {
        var config = new MapperConfiguration(cfg => { cfg.AddProfile<EntitiesMappingProfile>(); });
        Mapper = new Mapper(config);
    }

    private IMapper Mapper { get; }

    public void Dispose()
    {
    }
}