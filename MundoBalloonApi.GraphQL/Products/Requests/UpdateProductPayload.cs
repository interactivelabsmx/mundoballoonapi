using MundoBalloonApi.business.DataObjects.Entities;

namespace MundoBalloonApi.graphql.Products.Requests;

public class UpdateProductPayload
{
    public UpdateProductPayload(Product product)
    {
        Product = product;
    }
    
    public Product Product { get; }
}