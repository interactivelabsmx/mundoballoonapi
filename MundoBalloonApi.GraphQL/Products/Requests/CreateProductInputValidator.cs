using FluentValidation;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products.Requests;

public class CreateProductInputValidator : AbstractValidator<Product>
{
    public CreateProductInputValidator()
    {
        RuleFor(input => input.Name).NotEmpty();
        RuleFor(input => input.Description).NotEmpty();
        RuleFor(input => input.Price).NotEmpty();
        RuleFor(input => input.ProductCategoryId).NotEmpty();
    }
}