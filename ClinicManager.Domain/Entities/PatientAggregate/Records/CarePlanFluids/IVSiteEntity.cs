namespace ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids
{
    public class IVSiteEntity : EntityBase
    {
        public IVSiteEntity()
        { }

        public IVSiteEntity(TimeSpan time, int frequency, string signature, PatientEntity patient)
        {
            _checkIVSiteTime = time;
            _checkIVSiteFrequency = frequency;
            _checkIVSiteSignature = signature;
            _patientId = patient.Id;
        }

        private TimeSpan _checkIVSiteTime;
        public TimeSpan CheckIVSiteTime => _checkIVSiteTime;

        private int _checkIVSiteFrequency;
        public int CheckIVSiteFrequency => _checkIVSiteFrequency;

        private string _checkIVSiteSignature;
        public string CheckIVSiteSignature => _checkIVSiteSignature;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
