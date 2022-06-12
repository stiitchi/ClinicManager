using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Admission
{
    public interface IAdmissionService
    {
        Task<IResult<List<AdmissionDTO>>> GetAll();

        Task<IResult<AdmissionDTO>> GetById(int id);

        Task<IResult<int>> SaveAsync(AdmissionDTO request);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<int>> UpdateAsync(AdmissionDTO request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}
