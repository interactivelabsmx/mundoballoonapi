using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.graphql.Common.Requests;

namespace MundoBalloonApi.graphql.Products.Requests
{
    public class CreateProductPayload : ClientMutationBase
    {
        public CreateProductPayload(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}