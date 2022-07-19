using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Nurses
{
    public class NurseService : BaseService, INurseService
    {
        public NurseService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }
        public async Task<IResult<int>> AssignNurseToWard(UserDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.NurseEndpoint.AssignToWard, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.NurseEndpoint.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<PaginatedResult<UserDTO>> GetAllNursesTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.NurseEndpoint.GetAllNursesTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<UserDTO>();
        }

        public async Task<IResult<List<UserDTO>>> GetAllNurses()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.NurseEndpoint.GetAllNurses);
            return await response.ToResult<List<UserDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<UserDTO>>> GetAllNursesByWardId(int wardId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.NurseEndpoint.GetAllNursesByWardId(wardId));
            return await response.ToResult<List<UserDTO>>();
        }

        public async Task<IResult<UserDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.NurseEndpoint.GetById(id));
            return await response.ToResult<UserDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> GetForLookUp()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.NurseEndpoint.ForLookUp);
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<int>> SaveAsync(UserDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.NurseEndpoint.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> UpdateAsync(UserDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PutAsJsonAsync(Routes.NurseEndpoint.Save, request);
            return await response.ToResult<int>();
        }
    }
}
