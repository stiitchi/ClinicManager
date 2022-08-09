namespace ClinicManager.Shared.DTO_s
{
    public class DownloadPdfDTO
    {
        public string PDFName { get; set; }
        public byte[] PDF { get; set; }
        public string ReferenceNo { get; set; }
    }
}
