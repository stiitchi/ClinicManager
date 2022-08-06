using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Bed
{
    public interface IBedService
    {
        Task<IResult<List<BedDTO>>> GetAll();

        Task<IResult<BedDTO>> GetById(int id);

        Task<IResult<List<BedDTO>>> GetAllBedsByRoomId(int roomId);
        Task<IResult<List<BedDTO>>> GetAllOccupiedBedsByRoomId(int roomId);
        Task<IResult<List<BedDTO>>> GetAllUnoccupiedBedsByRoomId(int roomId);

        Task<IResult<List<LookupDTO>>> BedsByRoomIdLookup(string roomNo);

        Task<IResult<int>> SaveAsync(BedDTO request);

        Task<IResult<int>> AssignPatientToBed(MovePatientDTO movePatient);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<int>> UpdateAsync(BedDTO request);

        Task<IResult<int>> DeleteAsync(int id, int wardId);

        Task<PaginatedResult<BedDTO>> GetAllBedsTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

        Task<PaginatedResult<BedDTO>> GetAllBedsByRoomIdTable(int pageNumber, int pageSize, string searchString, int roomId, string[] orderBy);
        Task<PaginatedResult<BedDTO>> GetAllUnOccupiedBedsTable(int pageNumber, int pageSize, string searchString, int roomId, string[] orderBy);
        Task<PaginatedResult<BedDTO>> GetAllOccupiedBedsTable(int pageNumber, int pageSize, string searchString, int roomId, string[] orderBy);

    }
}
