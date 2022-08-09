using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.AzureBlobStorage
{
    public class AzureBlobStorageService : BaseService, IAzureBlobStorageService
    {
        public AzureBlobStorageService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }
        public async Task<IResult<bool>> GeneratePDF(SubscriptionDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.AzureBlobStorageEndpoints.GeneratePDF, request);

            return await response.ToResult<bool>();
        }
        public async Task<DownloadPdfDTO> DownloadPDF(string refNo)
        {
            var response = await _httpClient.GetFromJsonAsync<DownloadPdfDTO>(Routes.AzureBlobStorageEndpoints.DownloadPDF(refNo));
            return response;
        }
    }
}
