using Azure.Storage.Blobs;

namespace ClinicManager.Application.Interfaces.Services
{
    public interface IBlobFactory
    {
        Task<BlobContainerClient> CreateContainerAsync(string containerName, string connectionString, CancellationToken token);

        Task<BlobContainerClient> GetContainerAsync(string containerName, string connectionString, CancellationToken cancellationToken = default);

        Task<byte[]> GetBlob(string containerName, string blobName, string connectionString);
    }
}
