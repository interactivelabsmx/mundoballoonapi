using HotChocolate.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Storage;

namespace MundoBalloonApi.graphql.Products;

[Authorize]
public partial class ProductMutations
{
    public async Task<ProductVariant?> ProductVariantAddMedia(
        IFile file,
        ProductVariantMedium input,
        [Service] IProductService productService, IOptions<AzureStorageConfig> config,
        CancellationToken cancellationToken = default)
    {
        var storageConfig = config.Value;
        await using var stream = file.OpenReadStream();
        var contentInfo = await StorageHelper.UploadFileToStorage(stream, file.Name, storageConfig, cancellationToken);

        if (contentInfo != null)
        {
            input.Url = contentInfo.ToString();
            var productVariant = productService.ProductVariantAddMedia(input);
            return productVariant;
        }

        return null;
    }
}