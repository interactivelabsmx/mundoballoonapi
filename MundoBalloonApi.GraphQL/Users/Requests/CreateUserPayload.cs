using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.graphql.Common.Requests;

namespace MundoBalloonApi.graphql.Users.Requests
{
    public class CreateUserPayload : ClientMutationBase
    {
        public CreateUserPayload(User user)
        {
            User = user;
        }

        public User User { get; }
    }
}