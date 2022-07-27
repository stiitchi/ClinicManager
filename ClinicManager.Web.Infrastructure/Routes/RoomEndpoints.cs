namespace ClinicManager.Web.Infrastructure.Routes
{
    public class RoomEndpoints
    {
        public static string ForLookup = "api/Room/ForLookup";

        public static string Save = "api/Room";

        public static string GetAllRooms = "api/Room/GetAllRooms";

        public static string GetAllRoomsByWardId(int wardId)
        {
            return $"api/Room/GetAllRoomsByWardId?wardId={wardId}";
        }

        public static string GetById(int id)
        {
            return $"api/Room/{id}";
        }

        public static string Delete(int id, int wardId)
        {
            return $"api/Room/Delete?id={id}&wardId={wardId}";
        }
        public static string GetRoomsByRoomNumber(string roomNumber)
        {
            return $"api/Room/GetRoomsByRoomNumber?roomNumber={roomNumber}";
        }

        public static string RoomsByWardIdLookup(int wardId)
        {
            return $"api/Room/RoomsByWardIdLookup?wardId={wardId}";
        }

        public static string GetAllRoomsByWardIdTable(int pageNumber, int pageSize, string searchString, int wardId, string[] orderBy)
        {
            var url = $"api/Room/GetAllRoomsByWardIdTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&wardId={wardId}&orderBy=";
            if (orderBy?.Any() == true)
            {
                foreach (var orderByPart in orderBy)
                {
                    url += $"{orderByPart},";
                }
                url = url[..^1];
            }
            return url;
        }
    }
}
