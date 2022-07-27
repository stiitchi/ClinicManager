using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Room
{
    public class RoomService : BaseService, IRoomService
    {
        public RoomService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }

        public async Task<IResult<int>> DeleteAsync(int id, int wardId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.RoomEndpoints.Delete(id, wardId));
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<RoomDTO>>> GetAll()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.RoomEndpoints.GetAllRooms);
            return await response.ToResult<List<RoomDTO>>(); throw new NotImplementedException();
        }

        public async Task<PaginatedResult<RoomDTO>> GetAllRoomsByWardIdTable(int pageNumber, int pageSize, string searchString, int wardId, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.RoomEndpoints.GetAllRoomsByWardIdTable(pageNumber, pageSize, searchString, wardId, orderBy));
            return await response.ToPaginatedResult<RoomDTO>();
        }

        public async Task<IResult<List<RoomDTO>>> GetAllRoomsByWardId(int wardId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.RoomEndpoints.GetAllRoomsByWardId(wardId));
            return await response.ToResult<List<RoomDTO>>();
        }

        public async Task<IResult<RoomDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.RoomEndpoints.GetById(id));
            return await response.ToResult<RoomDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> GetForLookUp()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.RoomEndpoints.ForLookup);
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<RoomDTO>> GetRoomsByRoomNumber(string roomNumber)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.RoomEndpoints.GetRoomsByRoomNumber(roomNumber));
            return await response.ToResult<RoomDTO>();
        }

        public async Task<IResult<int>> SaveAsync(RoomDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.RoomEndpoints.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> UpdateAsync(RoomDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PutAsJsonAsync(Routes.RoomEndpoints.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<LookupDTO>>> RoomsByWardIdLookup(int wardId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.RoomEndpoints.RoomsByWardIdLookup(wardId));
            return await response.ToResult<List<LookupDTO>>();
        }
    }
}
