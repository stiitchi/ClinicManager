
namespace ClinicManager.Web.Infrastructure.Routes
{
    public class BedEndpoints
    {
        public static string ForLookUp = "api/Bed/ForLookup";

        public static string Save = "api/Bed";
        public static string AssignPatientToBed = "api/Bed/AssignPatientToBed";

        //public static string AssignPatientToBed = "api/Bed/AssignPatientToBed";

        public static string GetAllBeds = "api/Bed/GetAllBeds";

        public static string GetAllBedsByRoomId(int roomId)
        {
            return $"api/Bed/GetAllBedsByRoomId?roomId={roomId}";
        }
        public static string GetAllOccupiedBeds(int roomId)
        {
            return $"api/Bed/GetAllOccupiedBeds?roomId={roomId}";
        }
        public static string GetAllUnOccupiedBeds(int roomId)
        {
            return $"api/Bed/GetAllUnOccupiedBeds?roomId={roomId}";
        }

        public static string Delete(int id, int roomId)
        {
            return $"api/Bed/Delete?id={id}&roomId={roomId}";
        }
        public static string GetById(int id)
        {
            return $"api/Bed/{id}";
        }

        public static string BedsByRoomIdLookup(string roomNo)
        {
            return $"api/Bed/BedsByRoomIdLookup?roomNo={roomNo}";
        }

        public static string GetAllBedsByRoomIdTable(int pageNumber, int pageSize, string searchString, int roomId, string[] orderBy)
        {
            var url = $"api/Bed/GetAllBedsByRoomIdTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&roomId={roomId}&orderBy=";
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

        public static string GetAllUnOccupiedBedsTable(int pageNumber, int pageSize, string searchString, int roomId, string[] orderBy)
        {
            var url = $"api/Bed/GetAllUnOccupiedBedsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&roomId={roomId}&orderBy=";
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

        public static string GetAllOccupiedBedsTable(int pageNumber, int pageSize, string searchString, int roomId, string[] orderBy)
        {
            var url = $"api/Bed/GetAllOccupiedBedsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&roomId={roomId}&orderBy=";
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
        public static string GetAllBedsTable(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            var url = $"api/Bed/GetAllBedsTable?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
