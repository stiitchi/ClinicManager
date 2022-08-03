using ClinicManager.Shared.DTO_s.Faults;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Faults
{
    public class FaultService : BaseService, IFaultService
    {
        public FaultService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        { }

        public async Task<IResult<int>> SaveAsync(FaultsDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.FaultEndpoints.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.FaultEndpoints.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<FaultsDTO>> GetById(int id)
        {
            await ConfigureHeaders();  
            var response = await _httpClient.GetAsync(Routes.FaultEndpoints.GetById(id));
            return await response.ToResult<FaultsDTO>();
        }

        public async Task<PaginatedResult<FaultsDTO>> GetAllFaultsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.FaultEndpoints.GetAllFaultsTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<FaultsDTO>();
        }

        public async Task<PaginatedResult<FaultsDTO>> GetAllFaultsBySeverityTable(int pageNumber, int pageSize, string searchString, string severity, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.FaultEndpoints.GetAllFaultsBySeverityTable(pageNumber, pageSize, searchString, severity, orderBy));
            return await response.ToPaginatedResult<FaultsDTO>();
        }
    }
}
