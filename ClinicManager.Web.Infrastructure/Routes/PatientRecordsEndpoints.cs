
namespace ClinicManager.Web.Infrastructure.Routes
{
    public class PatientRecordsEndpoints
    {
        public static string AddComfortSleepRecord = "api/PatientRecord/AddComfortSleepRecord";
        public static string AddDailyCareRecord = "api/PatientRecord/AddDailyCareRecord";
        public static string AddCathetherRecord = "api/PatientRecord/AddCathetherRecord";
        public static string AddContinentRecord = "api/PatientRecord/AddContinentRecord";
        public static string Add24HourIntakeRecord = "api/PatientRecord/Add24HourIntakeRecord";
        public static string AddOralInputRecord = "api/PatientRecord/AddOralInputRecord";
        public static string AddOralOutputRecord = "api/PatientRecord/AddOralOutputRecord";
        public static string AddIVTestRecord = "api/PatientRecord/AddIVTestRecord";
        public static string AddBedBathAssist = "api/PatientRecord/AddBedBathAssist";
        public static string AddBedBathRecord = "api/PatientRecord/AddBedBathRecord";
        public static string AddSelfCareRecord = "api/PatientRecord/AddSelfCareRecord";
        public static string AddIsolationRecord = "api/PatientRecord/AddIsolationRecord";
        public static string AddMedicationRecord = "api/PatientRecord/AddMedicationRecord";
        public static string AddPostOperativeCareRecord = "api/PatientRecord/AddPostOperativeCareRecord";
        public static string AddTractionRecord = "api/PatientRecord/AddTractionRecord";
        public static string AddWoundCareRecord = "api/PatientRecord/AddWoundCareRecord";
        public static string AddAssistInChairRecord = "api/PatientRecord/AddAssistInChairRecord";
        public static string AddBedRestRecord = "api/PatientRecord/AddBedRestRecord";
        public static string AddExerciseRecord = "api/PatientRecord/AddExerciseRecord";
        public static string AddMobileImmobileRecord = "api/PatientRecord/AddMobileImmobileRecord";
        public static string AddWalkAssistanceRecord = "api/PatientRecord/AddWalkAssistanceRecord";
        public static string AddFullWardDietRecord = "api/PatientRecord/AddFullWardDietRecord";
        public static string AddNPORecord = "api/PatientRecord/AddNPORecord";
        public static string AddSpecialRecord = "api/PatientRecord/AddSpecialRecord";
        public static string AddBloodFrequencyRecord = "api/PatientRecord/AddBloodFrequencyRecord";
        public static string AddBloodGlucoseRecord = "api/PatientRecord/AddBloodGlucoseRecord";
        public static string AddNeuroLogicalRecord = "api/PatientRecord/AddNeuroLogicalRecord";
        public static string AddNeuroVascularRecord = "api/PatientRecord/AddNeuroVascularRecord";
        public static string AddUrineTestRecord = "api/PatientRecord/AddUrineTestRecord";
        public static string AddVitalSignRecord = "api/PatientRecord/AddVitalSignRecord";
        public static string AddInhalaNebsRecord = "api/PatientRecord/AddInhalaNebsRecord";
        public static string AddMaskTimeRecord = "api/PatientRecord/AddMaskTimeRecord";
        public static string AddNasalCannulRecord = "api/PatientRecord/AddNasalCannulRecord";
        public static string AddPolyMaskRecord = "api/PatientRecord/AddPolyMaskRecord";
        public static string AddProgressReportRecord = "api/PatientRecord/AddProgressReportRecord";
        public static string AddCommunicationRecord = "api/PatientRecord/AddCommunicationRecord";
        public static string AddHealthEducationRecord = "api/PatientRecord/AddHealthEducationRecord";
        public static string AddSupportRecord = "api/PatientRecord/AddSupportRecord";
        public static string AddCheckIDBandsRecord = "api/PatientRecord/AddCheckIDBandsRecord";
        public static string AddCotsideRecord = "api/PatientRecord/AddCotsideRecord";
        public static string AddSkinIntegrityReportRecord = "api/PatientRecord/AddSkinIntegrityReportRecord";
        public static string AddPressurePartCareTimeRecord = "api/PatientRecord/AddPressurePartCareTimeRecord";
        public static string AddRednessReportRecord = "api/PatientRecord/AddRednessReportRecord";
        public static string AddStoolChartRecord = "api/PatientRecord/AddStoolChartRecord";

     
        public static string DeleteComfortSleepRecord(int id)
        {
            return $"api/PatientRecord/DeleteComfortSleepRecord/{id}";
        }
        public static string DeleteDailyCareRecord(int id)
        {
            return $"api/PatientRecord/DeleteDailyCareRecord/{id}";
        }
        public static string DeleteCathetherRecord(int id)
        {
            return $"api/PatientRecord/DeleteCathetherRecord/{id}";
        }
        public static string DeleteContinentRecord(int id)
        {
            return $"api/PatientRecord/DeleteContinentRecord/{id}";
        }
        public static string Delete24HourCheckRecord(int id)
        {
            return $"api/PatientRecord/Delete24HourCheckRecord/{id}";
        }
        public static string DeleteIVCheckRecord(int id)
        {
            return $"api/PatientRecord/DeleteIVCheckRecord/{id}";
        }
        public static string DeleteOralCheckRecord(int id)
        {
            return $"api/PatientRecord/DeleteOralCheckRecord/{id}";
        }
        public static string DeleteBedBathAssistRecord(int id)
        {
            return $"api/PatientRecord/DeleteBedBathAssistRecord/{id}";
        }
        public static string DeleteBedBathRecord(int id)
        {
            return $"api/PatientRecord/DeleteBedBathRecord/{id}";
        }
        public static string DeleteSelfCareRecord(int id)
        {
            return $"api/PatientRecord/DeleteSelfCareRecord/{id}";
        }
        public static string DeleteIsolationRecord(int id)
        {
            return $"api/PatientRecord/DeleteIsolationRecord/{id}";
        }
        public static string DeleteMedicationRecord(int id)
        {
            return $"api/PatientRecord/DeleteMedicationRecord/{id}";
        }
        public static string DeletePostOperativeCareRecord(int id)
        {
            return $"api/PatientRecord/DeletePostOperativeCareRecord/{id}";
        }
        public static string DeleteTractionRecord(int id)
        {
            return $"api/PatientRecord/DeleteTractionRecord/{id}";
        }
        public static string DeleteWoundCareRecord(int id)
        {
            return $"api/PatientRecord/DeleteWoundCareRecord/{id}";
        }
        public static string DeleteAssistInChairRecord(int id)
        {
            return $"api/PatientRecord/DeleteAssistInChairRecord/{id}";
        }
        public static string DeleteBedRestRecord(int id)
        {
            return $"api/PatientRecord/DeleteBedRestRecord/{id}";
        }
        public static string DeleteExerciseRecord(int id)
        {
            return $"api/PatientRecord/DeleteExerciseRecord/{id}";
        }
        public static string DeleteMobileImmobileRecord(int id)
        {
            return $"api/PatientRecord/DeleteMobileImmobileRecord/{id}";
        }
        public static string DeleteWalkAssistanceRecord(int id)
        {
            return $"api/PatientRecord/DeleteWalkAssistanceRecord/{id}";
        }
        public static string DeleteFullWardDietRecord(int id)
        {
            return $"api/PatientRecord/DeleteFullWardDietRecord/{id}";
        }
        public static string DeleteNPORecord(int id)
        {
            return $"api/PatientRecord/DeleteDailyCareRecord/{id}";
        }
        public static string DeleteSpecialRecord(int id)
        {
            return $"api/PatientRecord/DeleteSpecialRecord/{id}";
        }
        public static string DeleteBloodFrequencyRecord(int id)
        {
            return $"api/PatientRecord/DeleteBloodFrequencyRecord/{id}";
        }
        public static string DeleteBloodGlucoseRecord(int id)
        {
            return $"api/PatientRecord/DeleteBloodGlucoseRecord/{id}";
        }
        public static string DeleteNeuroLogicalRecord(int id)
        {
            return $"api/PatientRecord/DeleteNeuroLogicalRecord/{id}";
        }
        public static string DeleteNeuroVascularRecord(int id)
        {
            return $"api/PatientRecord/DeleteNeuroVascularRecord/{id}";
        }
        public static string DeleteUrineTestRecord(int id)
        {
            return $"api/PatientRecord/DeleteUrineTestRecord/{id}";
        }
        public static string DeleteVitalSignRecord(int id)
        {
            return $"api/PatientRecord/DeleteVitalSignRecord/{id}";
        }
        public static string DeleteInhalaNebsRecord(int id)
        {
            return $"api/PatientRecord/DeleteInhalaNebsRecord/{id}";
        }
        public static string DeleteMaskTimeRecord(int id)
        {
            return $"api/PatientRecord/DeleteMaskTimeRecord/{id}";
        }
        public static string DeleteNasalCannulRecord(int id)
        {
            return $"api/PatientRecord/DeleteNasalCannulRecord/{id}";
        }
        public static string DeletePolyMaskRecord(int id)
        {
            return $"api/PatientRecord/DeletePolyMaskRecord/{id}";
        }
        public static string DeleteProgressReportRecord(int id)
        {
            return $"api/PatientRecord/DeleteProgressReportRecord/{id}";
        }
        public static string DeleteHealthEducationRecord(int id)
        {
            return $"api/PatientRecord/DeleteHealthEducationRecord/{id}";
        }
        public static string DeleteMaskCommunicationRecord(int id)
        {
            return $"api/PatientRecord/DeleteMaskCommunicationRecord/{id}";
        }
        public static string DeleteSupportRecord(int id)
        {
            return $"api/PatientRecord/DeleteSupportRecord/{id}";
        }
        public static string DeleteCheckIDBandRecord(int id)
        {
            return $"api/PatientRecord/DeleteCheckIDBandRecord/{id}";
        }
        public static string DeleteCotsideRecord(int id)
        {
            return $"api/PatientRecord/DeleteCotsideRecord/{id}";
        }
        public static string DeleteSkinReportRecord(int id)
        {
            return $"api/PatientRecord/DeleteSkinReportRecord/{id}";
        }
        public static string DeletePressurePartCareTimeRecord(int id)
        {
            return $"api/PatientRecord/DeletePressurePartCareTimeRecord/{id}";
        }
        public static string DeleteRednessReportRecord(int id)
        {
            return $"api/PatientRecord/DeleteRednessReportRecord/{id}";
        }
        public static string DeleteStoolChartRecord(int id)
        {
            return $"api/PatientRecord/DeleteStoolChartRecord/{id}";
        }



        public static string GetAllComfortSleepRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllComfortSleepRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllDailyCareRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllDailyCareRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllCathethersByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllCathethersByPatientId?patientId={patientId}";
        }
        public static string GetAllContinentsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllContinentsByPatientId?patientId={patientId}";
        }
        public static string GetAll24HourIntakesByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAll24HourIntakesByPatientId?patientId={patientId}";
        }
        public static string GetAllOralOutputChecksByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllOralOutputChecksByPatientId?patientId={patientId}";
        }
        public static string GetAllOralIntakeChecksByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllOralInputChecksByPatientId?patientId={patientId}";
        }
        public static string GetAllIVCheckByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllIVCheckByPatientId?patientId={patientId}";
        }
        public static string GetAllBedBathAssistRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllBedBathAssistRecordsByPatientId={patientId}";
        }
        public static string GetAllBedBathRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllBedBathRecordByPatientId?patientId={patientId}";
        }
        public static string GetAllSelfCareRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllSelfCareRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllIsolationRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllIsolationRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllMedicationRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllMedicationRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllPostOperativeCareRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllPostOperativeCareRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllTractionRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllTractionRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllWoundCareRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllWoundCareRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllAssistInChairRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllAssistInChairRecordByPatientId?patientId={patientId}";
        }
        public static string GetAllBedRestRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllBedRestRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllExerciseRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllExerciseRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllByMobilityRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllByMobilityRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllWalkAssistanceRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllWalkAssistanceRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllFullWardDietByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllFullWardDietByPatientId?patientId={patientId}";
        }
        public static string GetAllNPORecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllNPORecordByPatientId?patientId={patientId}";
        }
        public static string GetAllSpecialRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllSpecialRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllBloodGlucoseRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllBloodGlucoseRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllBloodFrequencyRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllBloodFrequencyRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllNeuroLogicalRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllNeuroLogicalRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllNeuroVascularPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllNeuroVascularPatientId?patientId={patientId}";
        }
        public static string GetAllUrineTestsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllUrineTestsByPatientId?patientId={patientId}";
        }
        public static string GetAllVitalSignRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllVitalSignRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllInhalaByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllInhalaByPatientId?patientId={patientId}";
        }
        public static string GetAllMaskByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllMaskByPatientId?patientId={patientId}";
        }
        public static string GetAllNassalCannulRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllNassalCannulRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllPolyMaskByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllPolyMaskByPatientId?patientId={patientId}";
        }
        public static string GetAllProgressReportsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllProgressReportsByPatientId?patientId={patientId}";
        }
        public static string GetAllCommunicationRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllCommunicationRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllHealthEducationByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllHealthEducationByPatientId?patientId={patientId}";
        }
        public static string GetAllSupportRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllSupportRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllCheckIDBandRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllCheckIDBandRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllCotsideRecordsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllCotsideRecordsByPatientId?patientId={patientId}";
        }
        public static string GetAllSkinReportsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllSkinReportsByPatientId?patientId={patientId}";
        }
        public static string GetAllPressurePartCareTimeByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllPressurePartCareTimeByPatientId?patientId={patientId}";
        }
        public static string GetAllRednessReportsById(int patientId)
        {
            return $"api/PatientRecord/GetAllRednessReportsById?patientId={patientId}";
        }
        public static string GetAllStoolChartsByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAllStoolChartsByPatientId?patientId={patientId}";
        }



        public static string GetComfortSleepRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetComfortSleepRecordByPatientId?patientId={patientId}";
        }
        public static string GetDailyCareRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetDailyCareRecordByPatientId?patientId={patientId}";
        }
        public static string GetCathetherRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetCathetherRecordByPatientId?patientId={patientId}";
        }
        public static string GetContinentByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetContinentByPatientId?patientId={patientId}";
        }
        public static string Get24HourIntakeByPatientId(int patientId)
        {
            return $"api/PatientRecord/Get24HourIntakeByPatientId?patientId={patientId}";
        }
        public static string GetOralCheckByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetOralCheckByPatientId?patientId={patientId}";
        }
        public static string GetIVCheckByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetIVCheckByPatientId?patientId={patientId}";
        }
        public static string GetBedBathAssistByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetBedBathAssistByPatientId?patientId={patientId}";
        }
        public static string GetBedBathPatientId(int patientId)
        {
            return $"api/PatientRecord/GetBedBathPatientId?patientId={patientId}";
        }
        public static string GetSelfCareRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetSelfCareRecordByPatientId?patientId={patientId}";
        }
        public static string GetIsolationRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetIsolationRecordByPatientId?patientId={patientId}";
        }
        public static string GetMedicationRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetMedicationRecordByPatientId?patientId={patientId}";
        }
        public static string GetPostOperativeRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetPostOperativeRecordByPatientId?patientId={patientId}";
        }
        public static string GetTractionByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetTractionByPatientId?patientId={patientId}";
        }
        public static string GetWoundCareByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetWoundCareByPatientId?patientId={patientId}";
        }
        public static string GetAssistInChairRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetAssistInChairRecordByPatientId?patientId={patientId}";
        }
        public static string GetBedRestRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetBedRestRecordByPatientId?patientId={patientId}";
        }
        public static string GetMobilityRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetMobilityRecordByPatientId?patientId={patientId}";
        }
        public static string GetExerciseRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetExerciseRecordByPatientId?patientId={patientId}";
        }
        public static string GetWalkAssistanceByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetWalkAssistanceByPatientId?patientId={patientId}";
        }
        public static string GetFullWardDietByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetFullWardDietByPatientId?patientId={patientId}";
        }
        public static string GetNPORecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetNPORecordByPatientId?patientId={patientId}";
        }
        public static string GetSpecialRecordPatientId(int patientId)
        {
            return $"api/PatientRecord/GetSpecialRecordPatientId?patientId={patientId}";
        }
        public static string GetBloodFrequencyRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetBloodFrequencyRecordByPatientId?patientId={patientId}";
        }
        public static string GetBloodGlucoseRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetBloodGlucoseRecordByPatientId?patientId={patientId}";
        }
        public static string GetNeuroLogicalRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetNeuroLogicalRecordByPatientId?patientId={patientId}";
        }
        public static string GetNeuroVascularRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetNeuroVascularRecordByPatientId?patientId={patientId}";
        }
        public static string GetUrineTestByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetUrineTestByPatientId?patientId={patientId}";
        }
        public static string GetVitalSignRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetVitalSignRecordByPatientId?patientId={patientId}";
        }
        public static string GetInhalaRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetInhalaRecordByPatientId?patientId={patientId}";
        }
        public static string GetMaskRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetMaskRecordByPatientId?patientId={patientId}";
        }
        public static string GetNassalCannulByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetNassalCannulByPatientId?patientId={patientId}";
        }
        public static string GetPolyMaskRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetPolyMaskRecordByPatientId?patientId={patientId}";
        }
        public static string GetProgressReportByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetProgressReportByPatientId?patientId={patientId}";
        }
        public static string GetCommunicationRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetCommunicationRecordByPatientId?patientId={patientId}";
        }
        public static string GetHealthEducationByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetHealthEducationByPatientId?patientId={patientId}";
        }
        public static string GetSupportRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetSupportRecordByPatientId?patientId={patientId}";
        }
        public static string GetCheckIDBandRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetCheckIDBandRecordByPatientId?patientId={patientId}";
        }
        public static string GetCotsideByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetCotsideByPatientId?patientId={patientId}";
        }
        public static string GetSkinReportByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetSkinReportByPatientId?patientId={patientId}";
        }
        public static string GetPressurePartTimeRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetPressurePartTimeRecordByPatientId?patientId={patientId}";
        }
        public static string GetRednessRecordByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetRednessRecordByPatientId?patientId={patientId}";
        }
        public static string GetStoolChartByPatientId(int patientId)
        {
            return $"api/PatientRecord/GetStoolChartByPatientId?patientId={patientId}";
        }
    }
}
