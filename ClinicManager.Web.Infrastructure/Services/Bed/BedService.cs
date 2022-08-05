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

        public async Task<IResult<int>> DeleteAsync(int id, int roomId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.BedEndpoints.Delete(id, roomId));
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

        public async Task<IResult<List<BedDTO>>> GetAllBedsByRoomId(int roomId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.GetAllBedsByRoomId(roomId));
            return await response.ToResult<List<BedDTO>>();
        }
        public async Task<IResult<List<BedDTO>>> GetAllOccupiedBedsByWardId(int wardId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.GetAllOccupiedBedsByWardId(wardId));
            return await response.ToResult<List<BedDTO>>();
        }
        public async Task<IResult<List<BedDTO>>> GetAllUnoccupiedBedsByWardId(int wardId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.GetAllUnoccupiedBedsByWardId(wardId));
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

        public async Task<PaginatedResult<BedDTO>> GetAllBedsByRoomIdTable(int pageNumber, int pageSize, string searchString, int roomId, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.GetAllBedsByRoomIdTable(pageNumber, pageSize, searchString, roomId, orderBy));
            return await response.ToPaginatedResult<BedDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> BedsByRoomIdLookup(string roomNo)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.BedEndpoints.BedsByRoomIdLookup(roomNo));
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<int>> AssignPatientToBed(MovePatientDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.BedEndpoints.AssignPatientToBed, request);
            return await response.ToResult<int>();
        }
    }
}
