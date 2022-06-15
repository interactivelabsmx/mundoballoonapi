using FluentValidation;
using MundoBalloonApi.graphql.Collections.Requests;
using MundoBalloonApi.graphql.Products.Requests;

namespace MundoBalloonApi.graphql;

public static class ServicesInputValidationExtensions
{
    public static IServiceCollection AddInputValidationServices(this IServiceCollection services)
    {
        return services
            .AddValidatorsFromAssemblyContaining<CreateProductInputValidator>()
            .AddValidatorsFromAssemblyContaining<CreateProductVariantInputValidator>()
            .AddValidatorsFromAssemblyContaining<UpdateProductInputValidator>()
            .AddValidatorsFromAssemblyContaining<UpdateProductVariantInputValidator>()
            .AddValidatorsFromAssemblyContaining<CreateProductCategoryInputValidator>();
    }
}