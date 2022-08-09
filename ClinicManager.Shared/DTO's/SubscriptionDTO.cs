namespace ClinicManager.Shared.DTO_s
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }
        public string ReferenceNo { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string ClinicName { get; set; }
        public string repFirstName { get; set; }
        public string repLastName { get; set; }
        public string ClinicAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int AmountOfNurses { get; set; }
        public string StoragePlan { get; set; }
        public string PdfPath { get; set; }
        public int PricePerNurse { get; set; }
        public int Amount { get; set; }
        public bool IsChecked { get; set; }
        public byte[] Image { get; set; }
    }
}
