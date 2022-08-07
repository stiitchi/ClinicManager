namespace ClinicManager.Domain.Entities.PatientAggregate.Records.Prescription
{
    public class PrescriptionEntity : EntityBase
    {
        public PrescriptionEntity()
        { }

        public PrescriptionEntity(string medicationName, double dose, double freq, string route, double durationOfQuantity, bool reqWS, 
                                  double reqQuantity,double pharQuantity, DateTime date,DateTime reqDate,  DateTime pharDate, PatientEntity patient)
        {
            _medicationName     = medicationName;
            _dose               = dose;
            _frequency          = freq;
            _route              = route;
            _durationOfQuantity = durationOfQuantity;
            _reqWS              = reqWS;
            _reqQuantity        = reqQuantity;
            _pharQuantity       = pharQuantity;
            _date               = date;
            _reqDate            = reqDate;
            _pharDate           = pharDate;
            _patientId          = patient.Id;
        }
        public void Set(string medicationName, double dose, double freq, string route, double durationOfQuantity, bool reqWS, double reqQuantity,
                                double pharQuantity, DateTime date, DateTime reqDate, DateTime pharDate, PatientEntity patient)
        {
            _medicationName = medicationName;
            _dose = dose;
            _frequency = freq;
            _route = route;
            _durationOfQuantity = durationOfQuantity;
            _reqWS = reqWS;
            _reqQuantity = reqQuantity;
            _pharQuantity = pharQuantity;
            _date = date;
            _reqDate = reqDate;
            _pharDate = pharDate;
            _patientId = patient.Id;
        }

        private DateTime _date;
        public DateTime Date => _date;

        private string _medicationName;
        public string MedicationName => _medicationName;

        private double _dose;
        public double Dose => _dose;

        private double _frequency;
        public double Frequency => _frequency;

        private bool _reqWS;
        public bool ReqWS => _reqWS;

        private DateTime _reqDate;
        public DateTime ReqDate => _reqDate;

        private DateTime _pharDate;
        public DateTime PharDate => _pharDate;

        private double _reqQuantity;
        public double ReqQuantity => _reqQuantity;

        private double _pharQuantity;
        public double PharQuantity => _pharQuantity;

        private double _durationOfQuantity;
        public double DurationOfQuantity => _durationOfQuantity;

        private string _route;
        public string Route => _route;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
