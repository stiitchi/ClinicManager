using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;

namespace ClinicManager.Domain.Entities.PatientAggregate.Medications
{
    public class PatientMedicationEntity : EntityBase
    {
        public PatientMedicationEntity()
        {}

        public PatientMedicationEntity(PatientEntity patient, MedicationEntity medication)
        { 
            _patientId = patient.Id;
            _medicationId = medication.Id;
        }

        public void Set(PatientEntity patient, MedicationEntity medication)
        {
            _patientId = patient.Id;
            _medicationId = medication.Id;
        }

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;

        public MedicationEntity Medication;
        private int _medicationId;
        public int MedicationId => _medicationId;
    }
}
