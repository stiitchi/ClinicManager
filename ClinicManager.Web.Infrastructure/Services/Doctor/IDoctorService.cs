using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Doctor
{
    public interface IDoctorService
    {
        Task<IResult<List<UserDTO>>> GetAllDoctors();

        Task<IResult<UserDTO>> GetById(int id);

        Task<IResult<List<UserDTO>>> GetAllDoctorsByPatientId(int patientId);

        Task<IResult<int>> SaveAsync(UserDTO request);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<int>> UpdateAsync(UserDTO request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<PaginatedResult<UserDTO>> GetAllDoctorsTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

        Task<IResult<int>> AssignDoctorToPatient(UserDTO request);

    }
}
