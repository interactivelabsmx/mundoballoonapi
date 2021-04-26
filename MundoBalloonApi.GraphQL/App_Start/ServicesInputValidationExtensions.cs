using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MundoBalloonApi.graphql.Users.Types;

namespace MundoBalloonApi.graphql
{
    public static class ServicesInputValidationExtensions
    {
        public static IServiceCollection AddInputValidationServices(this IServiceCollection services) =>
            services.AddValidatorsFromAssemblyContaining<CreateUserInputValidator>();
    }
}