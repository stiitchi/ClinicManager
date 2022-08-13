namespace ClinicManager.Domain.Entities.PatientAggregate.LabResults
{
    public class ChemistryEntity : EntityBase
    {
        public ChemistryEntity()
        {}

        public ChemistryEntity(string sodium, string potassium, string chloride, string carbonDioxide, string anionGap, 
                         string bun, string creatinine, string glucose, string hemoglobin, string calcium, PatientEntity patient)
        {
            _sodium = sodium;
            _potassium = potassium; 
            _chloride = chloride;
            _carbonDioxide = carbonDioxide;
            _anionGap = anionGap;
            _creatinine = creatinine;
            _glucose = glucose;
            _bun = bun;
            _hemoglobinA1c = hemoglobin;
            _calcium = calcium;
            _patientId = patient.Id;
        }

        public void Set(string sodium, string potassium, string chloride, string carbonDioxide, string anionGap,
                     string bun, string creatinine, string glucose, string hemoglobin, string calcium, PatientEntity patient)
        {
            _sodium = sodium;
            _potassium = potassium;
            _chloride = chloride;
            _carbonDioxide = carbonDioxide;
            _anionGap = anionGap;
            _creatinine = creatinine;
            _glucose = glucose;
            _bun = bun;
            _hemoglobinA1c = hemoglobin;
            _calcium = calcium;
            _patientId = patient.Id;
        }

        private string _sodium;
        public string Sodium => _sodium;

        private string _potassium;
        public string Potassium => _potassium;

        private string _chloride;
        public string Chloride => _chloride;

        private string _carbonDioxide;
        public string CarbonDioxide => _carbonDioxide;

        private string _anionGap;
        public string AnionGap => _anionGap;

        private string _bun;
        public string Bun => _bun;

        private string _creatinine;
        public string Creatinine => _creatinine;

        private string _glucose;
        public string Glucose => _glucose;

        private string _hemoglobinA1c;
        public string HemoglobinA1c => _hemoglobinA1c;

        private string _calcium;
        public string Calcium => _calcium;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
