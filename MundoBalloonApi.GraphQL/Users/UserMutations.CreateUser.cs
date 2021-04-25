using System.Threading;
using HotChocolate;
using HotChocolate.Execution;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.graphql.Users.Types;

namespace MundoBalloonApi.graphql.Users
{
    public partial class UserMutations
    {
        public CreateUserPayload CreateUser(
            CreateUserInput input,
            [Service] IUsersService usersService,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.UserId))
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage("UserId cannot be empty.")
                        .SetCode(nameof(EMAIL_EMPTY))
                        .Build());
            }
        }
    }
}