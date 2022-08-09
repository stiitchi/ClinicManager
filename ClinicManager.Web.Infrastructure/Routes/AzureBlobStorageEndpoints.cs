namespace ClinicManager.Web.Infrastructure.Routes
{
    public class AzureBlobStorageEndpoints
    {
        public static string Save = "api/AzureBlobStorage";
        public static string GeneratePDF = "api/AzureBlobStorage/AddPDFToBlobStorage";

        public static string DownloadPDF(string referenceNo)
        {
            return $"api/AzureBlobStorage/DownloadPDF?referenceNo={referenceNo}";
        }

    }
}
