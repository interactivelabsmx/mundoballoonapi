using FairyBread;
using FluentValidation;

namespace MundoBalloonApi.graphql.Products.Types
{
    public class CreateProductInputValidator : AbstractValidator<CreateProductInput>, IRequiresOwnScopeValidator
    {
        public CreateProductInputValidator()
        {
            RuleFor(cui => cui.UserId).NotEmpty();
        }
    }
}