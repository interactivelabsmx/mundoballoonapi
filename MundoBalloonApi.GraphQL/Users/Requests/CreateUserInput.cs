using MundoBalloonApi.graphql.Common.Requests;

namespace MundoBalloonApi.graphql.Users.Requests
{
    public class CreateUserInput : ClientMutationBase
    {
        public CreateUserInput(
            string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}