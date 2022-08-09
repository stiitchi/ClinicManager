using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ClinicManager.Application.Interfaces.Services;

namespace ClinicManager.Application.Helpers
{
    public class BlobFactory : IBlobFactory
    {
        public BlobFactory()
        {
        }

        public async Task<BlobContainerClient> CreateContainerAsync(string containerName, string connectionString, CancellationToken cancellationToken = default)
        {
            var container = new BlobContainerClient(connectionString, containerName);

            await container.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
            await container.SetAccessPolicyAsync(PublicAccessType.BlobContainer, cancellationToken: cancellationToken);
            return container;
        }

        public async Task<byte[]> GetBlob(string containerName, string blobName, string connectionString)
        {
            try
            {
                var container = new BlobContainerClient(connectionString, containerName);
                BlobClient blobClient = container.GetBlobClient(blobName);

                var blobExists = await blobClient.ExistsAsync();

                using (var ms = new MemoryStream())
                {
                    await blobClient.DownloadToAsync(ms);
                    return ms.ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BlobContainerClient> GetContainerAsync(string containerName, string connectionString, CancellationToken cancellationToken = default)
        {
            var container = new BlobContainerClient(connectionString, containerName);
            return container;
        }
    }
}
