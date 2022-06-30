using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Patient
{
    public interface IPatientService
    {
        Task<IResult<List<PatientDTO>>> GetAll();

        Task<IResult<PatientDTO>> GetById(int id);

        Task<IResult<PatientDTO>> GetPatientByIDNumber(long patientId);

        Task<IResult<int>> SaveAsync(PatientDTO request);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<int>> UpdateAsync(PatientDTO request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}
