using FairyBread;
using FluentValidation;

namespace MundoBalloonApi.graphql.Users.Requests
{
    public class CreateUserInputValidator : AbstractValidator<CreateUserInput>, IRequiresOwnScopeValidator
    {
        public CreateUserInputValidator()
        {
            RuleFor(cui => cui.UserId).NotEmpty();
        }
    }
}