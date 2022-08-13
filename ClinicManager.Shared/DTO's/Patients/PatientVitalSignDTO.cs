namespace ClinicManager.Shared.DTO_s.Patients
{
    public class PatientVitalSignDTO
    {
        public int VitalSignId { get; set; }
        public int PatientId { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string Pulse { get; set; }
        public string RespitoryRate { get; set; }
        public string BloodSaturation { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BodyMassIndex { get; set; }
        public DateTime LastTime { get; set; }
    }
}
