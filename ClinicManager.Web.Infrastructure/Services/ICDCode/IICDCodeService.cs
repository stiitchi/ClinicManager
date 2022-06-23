using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.ICDCode
{
    public interface IICDCodeService
    {
        Task<IResult<List<ICDCodeDTO>>> GetAll();

        Task<IResult<ICDCodeDTO>> GetById(int id);

        Task<IResult<List<PatientICDCodeDTO>>> GetAllPatientICDCodes(int patientId);

        Task<IResult<int>> SaveAsync(ICDCodeDTO request);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<int>> UpdateAsync(ICDCodeDTO request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<PaginatedResult<ICDCodeDTO>> GetAllICDCodesTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

        Task<IResult<int>> AssignICDCodeToPatient(PatientICDCodeDTO request);


    }
}
