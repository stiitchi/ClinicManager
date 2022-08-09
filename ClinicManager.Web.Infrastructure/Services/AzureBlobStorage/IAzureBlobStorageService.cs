using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.AzureBlobStorage
{
    public interface IAzureBlobStorageService
    {
        Task<IResult<bool>> GeneratePDF(SubscriptionDTO request);

        Task<DownloadPdfDTO> DownloadPDF(string refNo);
    }
}
