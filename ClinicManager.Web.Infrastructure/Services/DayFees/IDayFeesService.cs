using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.DayFees
{
    public interface IDayFeesService
    {
        Task<IResult<List<DayFeesDTO>>> GetAll();

        Task<IResult<DayFeesDTO>> GetById(int id);

        Task<IResult<int>> SaveAsync(DayFeesDTO request);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<int>> UpdateAsync(DayFeesDTO request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<PaginatedResult<DayFeesDTO>> GetAllDayFeesTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

    }
}
