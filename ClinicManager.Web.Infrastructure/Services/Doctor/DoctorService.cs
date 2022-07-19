using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Doctor
{
    public class DoctorService : BaseService, IDoctorService
    {
        public DoctorService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }
        public async Task<IResult<int>> AssignDoctorToPatient(UserDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.DoctorEndpoint.AssignToPatient, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.DoctorEndpoint.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<UserDTO>>> GetAllDoctors()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DoctorEndpoint.GetAllDoctors);
            return await response.ToResult<List<UserDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<UserDTO>>> GetAllDoctorsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DoctorEndpoint.GetAllDoctorByPatientId(patientId));
            return await response.ToResult<List<UserDTO>>();
        }

        public async Task<PaginatedResult<UserDTO>> GetAllDoctorsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DoctorEndpoint.GetAllDoctorTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<UserDTO>();
        }

        public async Task<IResult<UserDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DoctorEndpoint.GetById(id));
            return await response.ToResult<UserDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> GetForLookUp()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DoctorEndpoint.ForLookUp);
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<int>> SaveAsync(DoctorDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.DoctorEndpoint.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> UpdateAsync(UserDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PutAsJsonAsync(Routes.DoctorEndpoint.Save, request);
            return await response.ToResult<int>();
        }
    }
}
