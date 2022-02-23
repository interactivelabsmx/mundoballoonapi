using FluentValidation;
using MundoBalloonApi.business.DataObjects.Requests.Products;

namespace MundoBalloonApi.graphql.Products.Requests;

public class UpdateProductInputValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductInputValidator()
    {
        RuleFor(input => input.ProductId).NotEmpty();
        RuleFor(input => input.Name).NotEmpty();
        RuleFor(input => input.Description).NotEmpty();
        RuleFor(input => input.Price).NotEmpty();
        RuleFor(input => input.ProductCategoryId).NotEmpty();
    }
}