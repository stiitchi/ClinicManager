using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Ward
{
    public class WardService : BaseService, IWardService
    {
        public WardService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.WardEndpoint.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<WardDTO>>> GetAll()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.WardEndpoint.GetAllWards);
            return await response.ToResult<List<WardDTO>>(); throw new NotImplementedException();
        }

        public async Task<PaginatedResult<WardDTO>> GetAllWardsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.WardEndpoint.GetAllWardsTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<WardDTO>();
        }

        public async Task<IResult<WardDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.WardEndpoint.GetById(id));
            return await response.ToResult<WardDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> GetForLookUp()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.WardEndpoint.ForLookUp);
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<WardDTO>> GetWardsByWardNumber(string wardNumber)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.WardEndpoint.GetWardsByWardNumber(wardNumber));
            return await response.ToResult<WardDTO>();
        }

        public async Task<IResult<int>> SaveAsync(WardDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.WardEndpoint.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> UpdateAsync(WardDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PutAsJsonAsync(Routes.WardEndpoint.Save, request);
            return await response.ToResult<int>();
        }
    }
}
