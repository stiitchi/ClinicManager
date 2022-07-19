using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Nurses
{
    public interface INurseService
    {
        Task<IResult<List<UserDTO>>> GetAllNurses();

        Task<IResult<UserDTO>> GetById(int id);

        Task<IResult<List<UserDTO>>> GetAllNursesByWardId(int wardId);

        Task<IResult<int>> SaveAsync(UserDTO request);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<int>> UpdateAsync(UserDTO request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<PaginatedResult<UserDTO>> GetAllNursesTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

        Task<IResult<int>> AssignNurseToWard(UserDTO request);

    }
}
