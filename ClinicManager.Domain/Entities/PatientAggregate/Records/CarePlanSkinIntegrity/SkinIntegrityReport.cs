
namespace ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanSkinIntegrity
{
    public class SkinIntegrityReport : EntityBase
    {
       public SkinIntegrityReport()
        {}
        public SkinIntegrityReport(string sacrum, string hips, string heals, string other , string comments, PatientEntity patient)
        {
            _sacrumDescription = sacrum;
            _hipsDescription = hips;
            _healsDescription = heals;
            _otherDescription = other;
            _comments = comments;
            _patientId = patient.Id;
        }

        public void Set(string sacrum, string hips, string heals, string other, string comments, PatientEntity patient)
        {
            _sacrumDescription = sacrum;
            _hipsDescription = hips;
            _healsDescription = heals;
            _otherDescription = other;
            _comments = comments;
            _patientId = patient.Id;
        }

        private string _sacrumDescription;
        public string SacrumDescription => _sacrumDescription;

        private string _hipsDescription;
        public string HipsDescription => _hipsDescription;

        private string _healsDescription;
        public string HealsDescription => _healsDescription;

        private string _otherDescription;
        public string OtherDescription => _otherDescription;

        private string _comments;
        public string Comments => _comments;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;

    }
}
