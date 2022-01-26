using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    [UseDbContext(typeof(MundoBalloonContext))]
    public Boolean? DeleteProduct(
        [ScopedService] MundoBalloonContext mundoBalloonContext, int productId)
    {
        var product = mundoBalloonContext.Products.FirstOrDefault(p => p.ProductId == productId);
        if (product != null)
        {
            mundoBalloonContext.Products.Remove(product);
            mundoBalloonContext.SaveChanges();
            return true;
        }
        return false;
    }
}