using FairyBread;
using FluentValidation;

namespace MundoBalloonApi.graphql.Products.Requests
{
    public class CreateProductInputValidator : AbstractValidator<CreateProductInput>, IRequiresOwnScopeValidator
    {
        public CreateProductInputValidator()
        {
            RuleFor(cui => cui.UserId).NotEmpty();
        }
    }
}