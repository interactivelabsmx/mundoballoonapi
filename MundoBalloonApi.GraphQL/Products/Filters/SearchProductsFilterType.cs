using HotChocolate.Data.Filters;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Products.Filters;

public class SearchProductsFilterType : FilterInputType<Product>
{
    protected override void Configure(IFilterInputTypeDescriptor<Product> descriptor)
    {
        descriptor.Ignore(p => p.Category);
        base.Configure(descriptor);
    }
}