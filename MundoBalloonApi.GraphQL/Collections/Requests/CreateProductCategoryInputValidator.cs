using FluentValidation;
using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Collections.Requests;

public class CreateProductCategoryInputValidator : AbstractValidator<ProductCategory>
{
    public CreateProductCategoryInputValidator()
    {
        RuleFor(input => input.Name).NotEmpty();
        RuleFor(input => input.Description).NotEmpty();
    }
}