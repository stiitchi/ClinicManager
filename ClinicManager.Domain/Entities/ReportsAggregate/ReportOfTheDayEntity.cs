using ClinicManager.Domain.Entities.PatientAggregate;

namespace ClinicManager.Domain.Entities.ReportsAggregate
{
    public class ReportOfTheDayEntity :  EntityBase
    {
        public ReportOfTheDayEntity()
        {}

        public ReportOfTheDayEntity(int? progressReportAmount, int? dailyCareRecordsAmount, int? eliminationRecordsAmount, int? fluidBalanceRecordsAmount, 
                                    int? hygieneRecordsAmount, int? interventionRecordsAmount, int? mobilityRecordsAmount, int? nutritionRecordsAmount,
                                    int? observationRecordsAmount, int? oxygenationRecordsAmount, int? prescriptionRecordsAmount, int? psychologicalRecordsAmount,
                                    int? safetyRecordsAmount, int? skinIntegrityRecordsAmount, int? skinReportsAmount, int? stoolChartRecordsAmount)
        {
            _progressReportsAmount      = progressReportAmount;
            _dailyCareRecordsAmount     = dailyCareRecordsAmount;
            _eliminationRecordsAmount   = eliminationRecordsAmount;
            _fluidBalanceRecordsAmount  = fluidBalanceRecordsAmount;
            _hygieneRecordsAmount       = hygieneRecordsAmount;
            _interventionRecordsAmount  = interventionRecordsAmount;
            _mobilityRecordsAmount      = mobilityRecordsAmount;
            _nutritionRecordsAmount     = nutritionRecordsAmount;
            _observationRecordsAmount   = observationRecordsAmount;
            _oxygenationRecordsAmount   = oxygenationRecordsAmount;
            _prescriptionRecordsAmount  = prescriptionRecordsAmount;
            _psychologicalRecordsAmount = psychologicalRecordsAmount;
            _safetyRecordsAmount        = safetyRecordsAmount;
            _skinIntegrityRecordsAmount = skinIntegrityRecordsAmount;
            _skinReportsAmount          = skinReportsAmount;
            _stoolChartRecordsAmount    = stoolChartRecordsAmount;
        }

        private int? _progressReportsAmount;
        public int? ProgressReportsAmount => _progressReportsAmount;

        private int? _dailyCareRecordsAmount;
        public int? DailyCareRecordsAmount => _dailyCareRecordsAmount;

        private int? _eliminationRecordsAmount;
        public int? EliminationRecordsAmount => _eliminationRecordsAmount;

        private int? _fluidBalanceRecordsAmount;
        public int? FluidBalanceRecordsAmount => _fluidBalanceRecordsAmount;

        private int? _hygieneRecordsAmount;
        public int? HygieneRecordsAmount => _hygieneRecordsAmount;

        private int? _interventionRecordsAmount;
        public int? InterventionRecordsAmount => _interventionRecordsAmount;

        private int? _mobilityRecordsAmount;
        public int? MobilityRecordsAmount => _mobilityRecordsAmount;

        private int? _nutritionRecordsAmount;
        public int? NutritionRecordsAmount => _nutritionRecordsAmount;

        private int? _observationRecordsAmount;
        public int? ObservationRecordsAmount => _observationRecordsAmount;

        private int? _oxygenationRecordsAmount;
        public int? OxygenationRecordsAmount => _oxygenationRecordsAmount;

        private int? _prescriptionRecordsAmount;
        public int? PrescriptionRecordsAmount => _prescriptionRecordsAmount;

        private int? _psychologicalRecordsAmount;
        public int? PsychologicalRecordsAmount => _psychologicalRecordsAmount;

        private int? _safetyRecordsAmount;
        public int? SafetyRecordsAmount => _safetyRecordsAmount;

        private int? _skinIntegrityRecordsAmount;
        public int? SkinIntegrityRecordsAmount => _skinIntegrityRecordsAmount;

        private int? _skinReportsAmount;
        public int? SkinReportsAmount => _skinReportsAmount;

        private int? _stoolChartRecordsAmount;
        public int? StoolChartRecordsAmount => _stoolChartRecordsAmount;

        public PatientEntity Patient;
        private int _patientId;
        public int PatientId => _patientId;
    }
}
