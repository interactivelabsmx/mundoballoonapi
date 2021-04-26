using System.Threading;
using HotChocolate;
using HotChocolate.Execution;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Requests;
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
            var user = usersService.Create(new CreateUserRequest()
            {
                UserId = input.UserId
            });
            return new CreateUserPayload(user);
        }
    }
}