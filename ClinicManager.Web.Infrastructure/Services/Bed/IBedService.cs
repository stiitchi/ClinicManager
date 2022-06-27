using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Bed
{
    public interface IBedService
    {
        Task<IResult<List<BedDTO>>> GetAll();

        Task<IResult<BedDTO>> GetById(int id);

        Task<IResult<List<BedDTO>>> GetAllBedsByWardId(int wardId);

        Task<IResult<List<LookupDTO>>> BedsByWardIdLookup(int wardId);

        Task<IResult<int>> SaveAsync(BedDTO request);

        Task<IResult<int>> AssignPatientToBed(int patientId, int bedId);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<int>> UpdateAsync(BedDTO request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<PaginatedResult<BedDTO>> GetAllBedsTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

        Task<PaginatedResult<BedDTO>> GetAllBedsByWardIdTable(int pageNumber, int pageSize, string searchString, int wardId, string[] orderBy);

    }
}
