using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Bed
{
    public class BedService : BaseService, IBedService
    {
        public BedService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.BedEndpoints.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<BedDTO>>> GetAll()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.GetAllBeds);
            return await response.ToResult<List<BedDTO>>(); throw new NotImplementedException();
        }

        public async Task<PaginatedResult<BedDTO>> GetAllBedsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.GetAllBedsTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<BedDTO>();
        }

        public async Task<IResult<BedDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.GetById(id));
            return await response.ToResult<BedDTO>();
        }

        public async Task<IResult<List<BedDTO>>> GetAllBedsByWardId(int wardId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.GetAllBedsByWardId(wardId));
            return await response.ToResult<List<BedDTO>>();
        }

        public async Task<IResult<List<LookupDTO>>> GetForLookUp()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.ForLookUp);
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<int>> SaveAsync(BedDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.BedEndpoints.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> UpdateAsync(BedDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PutAsJsonAsync(Routes.BedEndpoints.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<PaginatedResult<BedDTO>> GetAllBedsByWardIdTable(int pageNumber, int pageSize, string searchString, int wardId, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.GetAllBedsByWardIdTable(pageNumber, pageSize, searchString, wardId, orderBy));
            return await response.ToPaginatedResult<BedDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> BedsByWardIdLookup(int wardId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.BedsByWardIdLookup(wardId));
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<int>> AssignPatientToBed(int patientId, int bedId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.BedEndpoints.AssignPatientToBed(patientId, bedId), bedId);
            return await response.ToResult<int>();
        }
    }
}
