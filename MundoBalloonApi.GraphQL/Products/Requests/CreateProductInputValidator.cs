using FairyBread;
using FluentValidation;
using MundoBalloonApi.business.DataObjects.Requests;

namespace MundoBalloonApi.graphql.Products.Requests
{
    public class CreateProductInputValidator : AbstractValidator<CreateProductRequest>, IRequiresOwnScopeValidator
    {
        public CreateProductInputValidator()
        {
            RuleFor(input => input.Name).NotEmpty();
            RuleFor(input => input.Description).NotEmpty();
            RuleFor(input => input.Price).NotEmpty();
            RuleFor(input => input.ProductCategoryId).NotEmpty();
        }
    }
}