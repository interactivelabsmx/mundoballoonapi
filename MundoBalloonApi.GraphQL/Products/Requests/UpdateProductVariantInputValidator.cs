using FluentValidation;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products.Requests;

public class UpdateProductVariantInputValidator : AbstractValidator<ProductVariantEntity>
{
    public UpdateProductVariantInputValidator()
    {
        RuleFor(input => input.ProductVariantId).NotEmpty();
        RuleFor(input => input.Sku).NotEmpty();
        RuleFor(input => input.VariantValueId).NotEmpty();
        RuleFor(input => input.ProductId).NotEmpty();
        RuleFor(input => input.Name).NotEmpty();
        RuleFor(input => input.Description).NotEmpty();
        RuleFor(input => input.Price).NotEmpty();
    }
}