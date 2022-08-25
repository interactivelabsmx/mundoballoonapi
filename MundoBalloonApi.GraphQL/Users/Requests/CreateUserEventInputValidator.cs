using FluentValidation;
using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Collections.Requests;

public class CreateUserEventInputValidator : AbstractValidator<UserEvent>
{
    public CreateUserEventInputValidator()
    {
        RuleFor(input => input.UserEventId).NotEmpty();
        RuleFor(input => input.UserId).NotEmpty();
        RuleFor(input => input.Name).NotEmpty();
    }
}