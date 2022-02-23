using FluentValidation;
using MundoBalloonApi.business.DataObjects.Requests.Products;

namespace MundoBalloonApi.graphql.Products.Requests;

public class CreateProductVariantInputValidator : AbstractValidator<CreateProductVariantRequest>
{
    public CreateProductVariantInputValidator()
    {
        RuleFor(input => input.Sku).NotEmpty();
        RuleFor(input => input.VariantValueId).NotEmpty();
        RuleFor(input => input.ProductId).NotEmpty();
        RuleFor(input => input.Name).NotEmpty();
        RuleFor(input => input.Description).NotEmpty();
        RuleFor(input => input.Price).NotEmpty();
    }
}