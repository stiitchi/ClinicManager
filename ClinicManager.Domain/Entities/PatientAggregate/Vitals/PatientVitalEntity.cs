namespace ClinicManager.Domain.Entities.PatientAggregate.Vitals
{
    public class PatientVitalEntity : EntityBase
    {
        public PatientVitalEntity()
        {}

        public PatientVitalEntity(string temperature, string bloodPressure, string pulse, string respitoryRate, string bloodSaturation, 
                                  string height, string weight, string bmi, DateTime lastTime, PatientEntity patient)
        {
            _temperature     = temperature;
            _bloodPressure   = bloodPressure; 
            _pulse           = pulse;
            _respitoryRate   = respitoryRate;
            _bloodSaturation = bloodSaturation;
            _height          = height;
            _weight          = weight;
            _bodyMassIndex   = bmi;
            _lastTime        = lastTime;
            _patientId       = patient.Id;
        }

        public void Set(string temperature, string bloodPressure, string pulse, string respitoryRate, string bloodSaturation,
                                string height, string weight, string bmi, DateTime lastTime, PatientEntity patient)
        {
            _temperature     = temperature;
            _bloodPressure   = bloodPressure;
            _pulse           = pulse;
            _respitoryRate   = respitoryRate;
            _bloodSaturation = bloodSaturation;
            _height          = height;
            _weight          = weight;
            _bodyMassIndex   = bmi;
            _lastTime        = lastTime;
            _patientId       = patient.Id;
        }

        private string _temperature;
        public string Temperature => _temperature;

        private string _bloodPressure;
        public string BloodPressure => _bloodPressure;

        private string _pulse;
        public string Pulse => _pulse;

        private string _respitoryRate;
        public string RespitoryRate => _respitoryRate;

        private string _bloodSaturation;
        public string BloodSaturation => _bloodSaturation;

        private string _height;
        public string Height => _height;

        private string _weight;
        public string Weight => _weight;

        private string _bodyMassIndex;
        public string BodyMassIndex => _bodyMassIndex;

        private DateTime _lastTime;
        public DateTime LastTime => _lastTime;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
