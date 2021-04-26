using MundoBalloonApi.graphql.Common.Types;

namespace MundoBalloonApi.graphql.Users.Types
{
    public class CreateUserInput : ClientMutationBase
    {
        public CreateUserInput(
            string userId)
            : base()
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}