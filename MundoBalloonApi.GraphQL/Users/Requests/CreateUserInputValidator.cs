using FluentValidation;
using MundoBalloonApi.business.DataObjects.Requests.Users;

namespace MundoBalloonApi.graphql.Users.Requests;

public class CreateUserInputValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserInputValidator()
    {
        RuleFor(input => input.UserId).NotEmpty();
    }
}