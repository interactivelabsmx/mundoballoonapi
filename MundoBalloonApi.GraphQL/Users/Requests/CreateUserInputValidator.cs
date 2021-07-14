using FairyBread;
using FluentValidation;
using MundoBalloonApi.business.DataObjects.Requests;

namespace MundoBalloonApi.graphql.Users.Requests
{
    public class CreateUserInputValidator : AbstractValidator<CreateUserRequest>, IRequiresOwnScopeValidator
    {
        public CreateUserInputValidator()
        {
            RuleFor(input => input.UserId).NotEmpty();
        }
    }
}