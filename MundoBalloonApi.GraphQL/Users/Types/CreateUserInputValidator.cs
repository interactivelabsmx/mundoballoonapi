using FairyBread;
using FluentValidation;

namespace MundoBalloonApi.graphql.Users.Types
{
    public class CreateUserInputValidator : AbstractValidator<CreateUserInput>, IRequiresOwnScopeValidator
    {
        public CreateUserInputValidator()
        {
            RuleFor(cui => cui.UserId).NotEmpty();
        }
    }
}