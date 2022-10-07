using FluentValidation;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Users.Requests;

public class CreateUserEventInputValidator : AbstractValidator<UserEvent>
{
    public CreateUserEventInputValidator()
    {
        RuleFor(input => input.UserId).NotEmpty();
        RuleFor(input => input.Name).NotEmpty();
    }
}