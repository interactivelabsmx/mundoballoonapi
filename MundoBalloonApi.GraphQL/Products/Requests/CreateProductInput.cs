using MundoBalloonApi.graphql.Common.Requests;

namespace MundoBalloonApi.graphql.Products.Requests
{
    public class CreateProductInput : ClientMutationBase
    {
        public CreateProductInput(
            string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}