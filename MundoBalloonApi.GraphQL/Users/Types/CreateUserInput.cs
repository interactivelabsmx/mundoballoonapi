using MundoBalloonApi.graphql.Common.Types;

namespace MundoBalloonApi.graphql.Users.Types
{
    public class CreateUserInput : ClientMutationBase
    {
        public CreateUserInput(
            string UserId,
            string clientMutationId)
            : base(clientMutationId)
        {
            UserId = UserId;
        }

        public string UserId { get; }
    }
}