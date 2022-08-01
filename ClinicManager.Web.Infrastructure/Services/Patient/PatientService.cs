using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Patient
{
   public class PatientService : BaseService, IPatientService
    {
        public PatientService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.PatientEndpoint.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> DischargePatient(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientEndpoint.DischargePatient(patientId));
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<PatientDTO>>> GetAll()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientEndpoint.GetAllPatients);
            return await response.ToResult<List<PatientDTO>>(); throw new NotImplementedException();
        }

        public async Task<PaginatedResult<PatientDTO>> GetAllPatientsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientEndpoint.GetAllPatientsTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<PatientDTO>();
        }

        public async Task<IResult<PatientDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientEndpoint.GetById(id));
            return await response.ToResult<PatientDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> GetForLookUp()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientEndpoint.ForLookUp);
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<PatientDTO>> GetPatientByIDNumber(long patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientEndpoint.GetPatientByIDNumber(patientId));
            return await response.ToResult<PatientDTO>();
        }

        public async Task<IResult<int>> SaveAsync(PatientDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientEndpoint.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> UpdateAsync(PatientDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PutAsJsonAsync(Routes.PatientEndpoint.Save, request);
            return await response.ToResult<int>();
        }
    }
}
