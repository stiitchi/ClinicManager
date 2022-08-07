namespace ClinicManager.Shared.DTO_s.Records.Prescription
{
    public class PrescriptionDTO
    {
        public int PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public string MedicationName { get; set; }
        public double Dose { get; set; }
        public double Freq { get; set; }
        public string Route { get; set; }
        public double DurationOfQuantity { get; set; }
        public bool ReqWS { get; set; }
        public double ReqQuantity { get; set; }
        public DateTime ReqDate { get; set; }
        public double PharQuantity { get; set; }
        public DateTime PharDate { get; set; }
    }
}
