using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.Admission
{
   public class AdmissionService : BaseService, IAdmissionService
    {
        public AdmissionService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.AdmissionEndpoints.GetById(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<AdmissionDTO>>> GetAll()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.AdmissionEndpoints.GetAllAdmissions);
            return await response.ToResult<List<AdmissionDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<AdmissionDTO>> GetById(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.AdmissionEndpoints.GetById(id));
            return await response.ToResult<AdmissionDTO>();
        }

        public async Task<IResult<List<LookupDTO>>> GetForLookUp()
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.AdmissionEndpoints.ForLookUp);
            return await response.ToResult<List<LookupDTO>>();
        }

        public async Task<IResult<int>> SaveAsync(AdmissionDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.AdmissionEndpoints.AddAdmission, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> UpdateAsync(AdmissionDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PutAsJsonAsync(Routes.AdmissionEndpoints.Update, request);
            return await response.ToResult<int>();
        }
    }
}
