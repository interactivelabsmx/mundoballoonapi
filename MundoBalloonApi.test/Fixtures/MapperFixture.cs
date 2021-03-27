using System;
using AutoMapper;
using MundoBalloonApi.business.Middleware;

namespace MundoBalloonApi.test.Fixtures
{
    public class MapperFixture : IDisposable
    {
        public MapperFixture()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<RequestsMappingProfile>(); });
            mapper = new Mapper(config);
        }

        public IMapper mapper { get; }

        public void Dispose()
        {
        }
    }
}