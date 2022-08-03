using ClinicManager.Shared.DTO_s.Faults;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Faults
{
    public interface IFaultService
    {
        Task<IResult<FaultsDTO>> GetById(int id);

        Task<IResult<int>> SaveAsync(FaultsDTO request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<PaginatedResult<FaultsDTO>> GetAllFaultsTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

        Task<PaginatedResult<FaultsDTO>> GetAllFaultsBySeverityTable(int pageNumber, int pageSize, string searchString, string severity, string[] orderBy);
    }
}
