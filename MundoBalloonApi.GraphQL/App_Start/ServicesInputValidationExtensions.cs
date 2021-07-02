using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MundoBalloonApi.graphql.Users.Requests;

namespace MundoBalloonApi.graphql
{
    public static class ServicesInputValidationExtensions
    {
        public static IServiceCollection AddInputValidationServices(this IServiceCollection services)
        {
            return services.AddValidatorsFromAssemblyContaining<CreateUserInputValidator>();
        }
    }
}