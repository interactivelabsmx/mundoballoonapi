using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.Middleware;
using MundoBalloonApi.business.Services;
using MundoBalloonApi.graphql.Collections;
using MundoBalloonApi.graphql.Products;
using MundoBalloonApi.graphql.Site;
using MundoBalloonApi.graphql.Users;
using MundoBalloonApi.infrastructure.Data.Contracts;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.infrastructure.Data.Repositories;
using MundoBalloonApi.test.Fixtures;

namespace MundoBalloonApi.test.GraphQL.Fixtures;

public abstract class BaseServiceCollection : IDisposable
{
    protected BaseServiceCollection()
    {
        // arrange
        Executor = new ServiceCollection()
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<IProductsRepository, ProductsRepository>()
            .AddScoped<ICollectionsRepository, CollectionsRepository>()
            .AddScoped<IUsersService, UsersService>()
            .AddScoped<ISiteService, SiteService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<ICollectionsService, CollectionsService>()
            .AddPooledDbContextFactory<MundoBalloonContext>(
                options => options.UseInMemoryDatabase("MundoBalloonContext:Integration:Graphql"))
            .AddAutoMapper(typeof(EntitiesMappingProfile))
            .AddGraphQLServer()
            .AddType<UploadType>()
            .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<SiteQueries>()
            .AddTypeExtension<UserQueries>()
            .AddTypeExtension<ProductQueries>()
            .AddTypeExtension<UserEventQueries>()
            .AddTypeExtension<CollectionQueries>()
            .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<UserMutations>()
            .AddTypeExtension<ProductMutations>()
            .AddTypeExtension<CollectionMutations>()
            .AddSorting()
            .AddFiltering()
            .Services
            .BuildServiceProvider();
        ContextFactory = Executor.GetService<IDbContextFactory<MundoBalloonContext>>();
        var db = ContextFactory?.CreateDbContext();
        if (db == null) return;
        using (db)
        {
            var contextSeeded = new SeedDbContext(db);
            contextSeeded.Seed();
        }
    }

    protected IServiceProvider? Executor { get; private set; }
    protected IDbContextFactory<MundoBalloonContext>? ContextFactory { get; private set; }

    public void Dispose()
    {
        Executor = null;
        ContextFactory = null;
        GC.SuppressFinalize(this);
    }
}