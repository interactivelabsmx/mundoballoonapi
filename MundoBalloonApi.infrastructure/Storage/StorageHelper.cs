using Azure.Storage;
using Azure.Storage.Blobs;

namespace MundoBalloonApi.infrastructure.Storage;

public class StorageHelper
{
    public static async Task<Uri?> UploadFileToStorage(Stream fileStream, string fileName,
        AzureStorageConfig _storageConfig, CancellationToken cancellationToken)
    {
        // Create a URI to the blob
        var blobUri = new Uri("https://" +
                              _storageConfig.AccountName +
                              ".blob.core.windows.net/" +
                              _storageConfig.ImageContainer +
                              "/" + Guid.NewGuid() + fileName);

        var storageCredentials =
            new StorageSharedKeyCredential(_storageConfig.AccountName, _storageConfig.AccountKey);

        // Create the blob client.
        var blobClient = new BlobClient(blobUri, storageCredentials);

        // Upload the file
        await blobClient.UploadAsync(fileStream, cancellationToken);

        return blobClient.Uri;
    }
}