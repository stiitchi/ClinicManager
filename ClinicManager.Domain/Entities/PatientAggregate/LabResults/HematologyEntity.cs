namespace ClinicManager.Domain.Entities.PatientAggregate.LabResults
{
    public class HematologyEntity : EntityBase
    {
        public HematologyEntity()
        {}

        public HematologyEntity(string wbc, string rbc, string hgb, string hct, string mcv, string mchc, string pitCount, string totalCounted, PatientEntity patient)
        {
            _whiteBloodCount         = wbc;
            _redBloodCount           = rbc;
            _hemoglobin              = hgb;
            _hematocrit              = hct;
            _macrocyticAnemia        = mcv;
            _hemoglobinConcentration = mchc;
            _pitCount                = pitCount;
            _totalCounted            = totalCounted;
            _patientId               = patient.Id;
        }

        public void Set(string wbc, string rbc, string hgb, string hct, string mcv, string mchc, string pitCount, string totalCounted, PatientEntity patient)
        {
            _whiteBloodCount         = wbc;
            _redBloodCount           = rbc;
            _hemoglobin              = hgb;
            _hematocrit              = hct;
            _macrocyticAnemia        = mcv;
            _hemoglobinConcentration = mchc;
            _pitCount                = pitCount;
            _totalCounted            = totalCounted;
            _patientId               = patient.Id;
        }

        private string _whiteBloodCount;
        public string WhiteBloodCount => _whiteBloodCount;

        private string _redBloodCount;
        public string RedBloodCount => _redBloodCount;

        private string _hemoglobin;
        public string Hemoglobin => _hemoglobin;

        private string _hematocrit;
        public string Hematocrit => _hematocrit;

        private string _meanCorpuscularVolume;
        public string MeanCorpuscularVolume => _meanCorpuscularVolume;

        private string _macrocyticAnemia;
        public string MacrocyticAnemia => _macrocyticAnemia;

        private string _hemoglobinConcentration;
        public string HemoglobinConcentration => _hemoglobinConcentration;

        private string _pitCount;
        public string PitCount => _pitCount;

        private string _totalCounted;
        public string TotalCounted => _totalCounted;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
