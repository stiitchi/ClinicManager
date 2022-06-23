using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.DayFees
{
      public class DayFeesService : BaseService, IDayFeesService
    {
        public DayFeesService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }

        public async Task<IResult<int>> AssignDayFeeToPatient(PatientDayFeeDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.DayFeeEndpoints.AssignToPatient, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.DayFeeEndpoints.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<DayFeesDTO>>> GetAll()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DayFeeEndpoints.GetAllDayFees);
            return await response.ToResult<List<DayFeesDTO>>(); throw new NotImplementedException();
        }

        public async Task<PaginatedResult<DayFeesDTO>> GetAllDayFeesTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DayFeeEndpoints.GetAllDayFeesTable(pageNumber, pageSize, searchString, orderBy));
            return await response.ToPaginatedResult<DayFeesDTO>();
        }

        public async Task<IResult<List<PatientDayFeeDTO>>> GetAllPatientDayFees(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DayFeeEndpoints.GetAllPatientDayFees(patientId));
            return await response.ToResult<List<PatientDayFeeDTO>>();
        }

        public async Task<IResult<DayFeesDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DayFeeEndpoints.GetById(id));
            return await response.ToResult<DayFeesDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> GetForLookUp()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.DayFeeEndpoints.ForLookUp);
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<int>> SaveAsync(DayFeesDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.DayFeeEndpoints.Save, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> UpdateAsync(DayFeesDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PutAsJsonAsync(Routes.DayFeeEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}
