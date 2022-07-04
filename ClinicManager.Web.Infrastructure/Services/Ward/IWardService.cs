using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Ward
{
    public interface IWardService
    {
        Task<IResult<List<WardDTO>>> GetAll();

        Task<IResult<WardDTO>> GetById(int id);
        Task<IResult<WardDTO>> GetWardsByWardNumber(string wardNumber);

        Task<IResult<int>> SaveAsync(WardDTO request);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<int>> UpdateAsync(WardDTO request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<PaginatedResult<WardDTO>> GetAllWardsTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

    }
}
