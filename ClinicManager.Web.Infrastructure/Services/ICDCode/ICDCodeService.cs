using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.ICDCode
{
    public class ICDCodeService : BaseService, IICDCodeService
    {
        public ICDCodeService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        { }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.ICDCodeEndpoints.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<ICDCodeDTO>>> GetAll()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ICDCodeEndpoints.GetAllICDCodes);
            return await response.ToResult<List<ICDCodeDTO>>(); throw new NotImplementedException();
        }

        public async Task<PaginatedResult<ICDCodeDTO>> GetAllICDCodesTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ICDCodeEndpoints.GetAllICDCodesTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<ICDCodeDTO>();
        }

        public async Task<IResult<ICDCodeDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ICDCodeEndpoints.GetById(id));
            return await response.ToResult<ICDCodeDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> GetForLookUp()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.ICDCodeEndpoints.ForLookup);
            return await response.ToResult<List<LookupDTO>>();
        } 

        public async Task<IResult<int>> SaveAsync(ICDCodeDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.ICDCodeEndpoints.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> UpdateAsync(ICDCodeDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PutAsJsonAsync(Routes.ICDCodeEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}
