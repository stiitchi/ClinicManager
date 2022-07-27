using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Room
{
    public interface IRoomService
    {
        Task<IResult<List<RoomDTO>>> GetAll();

        Task<IResult<RoomDTO>> GetById(int id);
        Task<IResult<List<RoomDTO>>> GetAllRoomsByWardId(int wardId);
        Task<IResult<RoomDTO>> GetRoomsByRoomNumber(string roomNumber);

        Task<IResult<int>> SaveAsync(RoomDTO request);

        Task<IResult<List<LookupDTO>>> GetForLookUp();

        Task<IResult<List<LookupDTO>>> RoomsByWardIdLookup(int wardId);


        Task<IResult<int>> UpdateAsync(RoomDTO request);

        Task<IResult<int>> DeleteAsync(int id, int wardId);

        Task<PaginatedResult<RoomDTO>> GetAllRoomsByWardIdTable(int pageNumber, int pageSize, string searchString, int wardId, string[] orderBy);
    }
}
