using MundoBalloonApi.business.DTOs.Models;
using MundoBalloonApi.graphql.Common.Types;

namespace MundoBalloonApi.graphql.Users.Types
{
    public class CreateUserPayload : ClientMutationBase
    {
        public CreateUserPayload(User user, string clientMutationId) : base(clientMutationId)
        {
            User = user;
        }

        public User User { get; }
    }
}