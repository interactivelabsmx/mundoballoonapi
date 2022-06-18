using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Storage;

namespace MundoBalloonApi.graphql.Products;

public partial class ProductMutations
{
    [Authorize(Roles = new[] { "ADMIN" })]
    public async Task<ProductVariant?> ProductVariantAddMedia(
        IFile file,
        ProductVariantMedium input,
        [Service] IProductService productService, [Service] IConfiguration configuration,
        CancellationToken cancellationToken = default)
    {
        var storageConfig = configuration.GetSection(AzureStorageConfig.ConfigName).Get<AzureStorageConfig>();
        await using var stream = file.OpenReadStream();
        var contentInfo = await StorageHelper.UploadFileToStorage(stream, file.Name, storageConfig, cancellationToken);
        if (contentInfo == null) return null;
        input.Url = contentInfo.ToString();
        return await productService.ProductVariantAddMedia(input);
    }
}