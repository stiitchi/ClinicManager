using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.DTO_s.Records.Elimination;
using ClinicManager.Shared.DTO_s.Records.FluidBalance;
using ClinicManager.Shared.DTO_s.Records.Hygiene;
using ClinicManager.Shared.DTO_s.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records.Mobility;
using ClinicManager.Shared.DTO_s.Records.Nutrition;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.DTO_s.Records.Oxygenation;
using ClinicManager.Shared.DTO_s.Records.Psychological;
using ClinicManager.Shared.DTO_s.Records.Safety;
using ClinicManager.Shared.DTO_s.Records.SkinIntegrity;
using ClinicManager.Shared.DTO_s.Records.SkinReport;
using ClinicManager.Shared.Wrappers;
using ClinicManager.Web.Infrastructure.Extensions;
using ClinicManager.Web.Infrastructure.Services.State;
using System.Net.Http.Json;

namespace ClinicManager.Web.Infrastructure.Services.PatientRecords
{
    public class PatientRecordService : BaseService, IPatientRecordService
    {
        public PatientRecordService(HttpClient httpClient, IStateService stateService) : base(httpClient, stateService)
        {
        }
        public async Task<IResult<int>> Add24HourIntakeRecord(Previous24HourIntakeDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.Add24HourIntakeRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddAssistInChairRecord(AssistIntoChairDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddAssistInChairRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddBedBathAssist(BedBathAssistDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddBedBathAssist, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddBedBathRecord(BedBathDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddBedBathRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddBedRestRecord(BedRestDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddBedRestRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddBloodFrequencyRecord(BloodDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddBloodFrequencyRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddBloodGlucoseRecord(BloodGlucoseDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddBloodGlucoseRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddCathetherRecord(CathetherDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddCathetherRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddCheckIDBandsRecord(CheckIDBandDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddCheckIDBandsRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddComfortSleepRecord(ComfortSleepReportDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddComfortSleepRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddCommunicationRecord(CommunicationDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddCommunicationRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddContinentRecord(ContinentDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddContinentRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddCotsideRecord(CotsideDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddCotsideRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddDailyCareRecord(DailyCareRecordDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddDailyCareRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddExerciseRecord(ExerciseDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddExerciseRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddFullWardDietRecord(FullWardDietDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddFullWardDietRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddHealthEducationRecord(HealthEducationDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddHealthEducationRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddInhalaNebsRecord(InhalaNebsDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddInhalaNebsRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddIsolationRecord(IsolationDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddIsolationRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddIVTestRecord(FluidBalanceIVCheckDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddIVTestRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddMaskTimeRecord(MaskDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddMaskTimeRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddMedicationRecord(MedicationDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddMedicationRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddMobileImmobileRecord(MobileImmobileDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddMobileImmobileRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddNasalCannulRecord(NasalCannulaDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddNasalCannulRecord, request);
            return await response.ToResult<int>();
        }
        
        public async Task<IResult<int>> AddNeuroLogicalRecord(NeuroLogicalDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddNeuroLogicalRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddNeuroVascularRecord(NeuroVascularDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddNeuroVascularRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddNPORecord(KeepNPODTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddNPORecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddOralInputTestRecord(OralIntakeDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddOralInputRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddOralOutputTestRecord(OralOutputDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddOralOutputRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddPolyMaskRecord(PolyMaskDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddPolyMaskRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddPostOperativeCareRecord(PostOperativeCareDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddPostOperativeCareRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddPressurePartCareTimeRecord(PressurePartCareDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddPressurePartCareTimeRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddProgressReportRecord(ProgressReportDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddProgressReportRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddRednessReportRecord(RednessDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddRednessReportRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddSelfCareRecord(SelfCareDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddSelfCareRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddSkinIntegrityReportRecord(SkinReportDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddSkinIntegrityReportRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddSpecialRecord(SpecialDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddSpecialRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddStoolChartRecord(StoolChartDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddStoolChartRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddSupportRecord(SupportDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddSupportRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddTractionRecord(TractionDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddTractionRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddUrineTestRecord(UrineTestDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddUrineTestRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddVitalSignRecord(VitalSignDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddVitalSignRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddWalkAssistanceRecord(WalkWithAssistanceDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddWalkAssistanceRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> AddWoundCareRecord(WoundCareDTO request)
        {
            await ConfigureHeaders();
            var response = await _httpClient.PostAsJsonAsync(Routes.PatientRecordsEndpoints.AddWoundCareRecord, request);
            return await response.ToResult<int>();
        }

        public async Task<IResult<int>> DeleteComfortSleepRecord(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.DeleteAsync(Routes.PatientRecordsEndpoints.DeleteComfortSleepRecord(id));
            return await response.ToResult<int>();
        }

        public async Task<IResult<Previous24HourIntakeDTO>> Get24HourIntakeByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.Get24HourIntakeByPatientId(patientId));
            return await response.ToResult<Previous24HourIntakeDTO>();
        }

        public async Task<IResult<List<Previous24HourIntakeDTO>>> GetAll24HourIntakesByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAll24HourIntakesByPatientId(patientId));
            return await response.ToResult<List<Previous24HourIntakeDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<AssistIntoChairDTO>>> GetAllAssistInChairRecordByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllAssistInChairRecordByPatientId(patientId));
            return await response.ToResult<List<AssistIntoChairDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<BedBathAssistDTO>>> GetAllBedBathAssistRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllBedBathAssistRecordsByPatientId(patientId));
            return await response.ToResult<List<BedBathAssistDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<BedBathDTO>>> GetAllBedBathRecordByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllBedBathRecordByPatientId(patientId));
            return await response.ToResult<List<BedBathDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<BedRestDTO>>> GetAllBedRestRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllBedRestRecordsByPatientId(patientId));
            return await response.ToResult<List<BedRestDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<BloodDTO>>> GetAllBloodFrequencyRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllBloodFrequencyRecordsByPatientId(patientId));
            return await response.ToResult<List<BloodDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<BloodGlucoseDTO>>> GetAllBloodGlucoseRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllBloodGlucoseRecordsByPatientId(patientId));
            return await response.ToResult<List<BloodGlucoseDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<MobileImmobileDTO>>> GetAllByMobilityRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllByMobilityRecordsByPatientId(patientId));
            return await response.ToResult<List<MobileImmobileDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<CathetherDTO>>> GetAllCathethersByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllCathethersByPatientId(patientId));
            return await response.ToResult<List<CathetherDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<CheckIDBandDTO>>> GetAllCheckIDBandRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllCheckIDBandRecordsByPatientId(patientId));
            return await response.ToResult<List<CheckIDBandDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<ComfortSleepReportDTO>>> GetAllComfortSleepRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllComfortSleepRecordsByPatientId(patientId));
            return await response.ToResult<List<ComfortSleepReportDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<CommunicationDTO>>> GetAllCommunicationRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllCommunicationRecordsByPatientId(patientId));
            return await response.ToResult<List<CommunicationDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<ContinentDTO>>> GetAllContinentsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllContinentsByPatientId(patientId));
            return await response.ToResult<List<ContinentDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<CotsideDTO>>> GetAllCotsideRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllCotsideRecordsByPatientId(patientId));
            return await response.ToResult<List<CotsideDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<DailyCareRecordDTO>>> GetAllDailyCareRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllDailyCareRecordsByPatientId(patientId));
            return await response.ToResult<List<DailyCareRecordDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<ExerciseDTO>>> GetAllExerciseRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllExerciseRecordsByPatientId(patientId));
            return await response.ToResult<List<ExerciseDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<FullWardDietDTO>>> GetAllFullWardDietByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllFullWardDietByPatientId(patientId));
            return await response.ToResult<List<FullWardDietDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<HealthEducationDTO>>> GetAllHealthEducationByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllHealthEducationByPatientId(patientId));
            return await response.ToResult<List<HealthEducationDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<InhalaNebsDTO>>> GetAllInhalaByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllInhalaByPatientId(patientId));
            return await response.ToResult<List<InhalaNebsDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<IsolationDTO>>> GetAllIsolationRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllInhalaByPatientId(patientId));
            return await response.ToResult<List<IsolationDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<FluidBalanceIVCheckDTO>>> GetAllIVCheckByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllIVCheckByPatientId(patientId));
            return await response.ToResult<List<FluidBalanceIVCheckDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<MaskDTO>>> GetAllMaskByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllMaskByPatientId(patientId));
            return await response.ToResult<List<MaskDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<MedicationDTO>>> GetAllMedicationRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllMedicationRecordsByPatientId(patientId));
            return await response.ToResult<List<MedicationDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<NasalCannulaDTO>>> GetAllNassalCannulRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllNassalCannulRecordsByPatientId(patientId));
            return await response.ToResult<List<NasalCannulaDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<NeuroLogicalDTO>>> GetAllNeuroLogicalRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllNeuroLogicalRecordsByPatientId(patientId));
            return await response.ToResult<List<NeuroLogicalDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<NeuroVascularDTO>>> GetAllNeuroVascularPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllNeuroVascularPatientId(patientId));
            return await response.ToResult<List<NeuroVascularDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<KeepNPODTO>>> GetAllNPORecordByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllNPORecordByPatientId(patientId));
            return await response.ToResult<List<KeepNPODTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<OralIntakeDTO>>> GetAllOralIntakeChecksByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllOralIntakeChecksByPatientId(patientId));
            return await response.ToResult<List<OralIntakeDTO>>(); throw new NotImplementedException(); 
        }

        public async Task<IResult<List<OralOutputDTO>>> GetAllOralOutputChecksByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllOralOutputChecksByPatientId(patientId));
            return await response.ToResult<List<OralOutputDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<PolyMaskDTO>>> GetAllPolyMaskByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllPolyMaskByPatientId(patientId));
            return await response.ToResult<List<PolyMaskDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<PostOperativeCareDTO>>> GetAllPostOperativeCareRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllPostOperativeCareRecordsByPatientId(patientId));
            return await response.ToResult<List<PostOperativeCareDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<PressurePartCareDTO>>> GetAllPressurePartCareTimeByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllPressurePartCareTimeByPatientId(patientId));
            return await response.ToResult<List<PressurePartCareDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<ProgressReportDTO>>> GetAllProgressReportsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllProgressReportsByPatientId(patientId));
            return await response.ToResult<List<ProgressReportDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<RednessDTO>>> GetAllRednessReportsById(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllRednessReportsById(patientId));
            return await response.ToResult<List<RednessDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<SelfCareDTO>>> GetAllSelfCareRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllSelfCareRecordsByPatientId(patientId));
            return await response.ToResult<List<SelfCareDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<SkinReportDTO>>> GetAllSkinReportsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllSkinReportsByPatientId(patientId));
            return await response.ToResult<List<SkinReportDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<SpecialDTO>>> GetAllSpecialRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllSpecialRecordsByPatientId(patientId));
            return await response.ToResult<List<SpecialDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<StoolChartDTO>>> GetAllStoolChartsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllStoolChartsByPatientId(patientId));
            return await response.ToResult<List<StoolChartDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<SupportDTO>>> GetAllSupportRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllSupportRecordsByPatientId(patientId));
            return await response.ToResult<List<SupportDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<TractionDTO>>> GetAllTractionRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllTractionRecordsByPatientId(patientId));
            return await response.ToResult<List<TractionDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<UrineTestDTO>>> GetAllUrineTestsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllUrineTestsByPatientId(patientId));
            return await response.ToResult<List<UrineTestDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<VitalSignDTO>>> GetAllVitalSignRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllVitalSignRecordsByPatientId(patientId));
            return await response.ToResult<List<VitalSignDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<WalkWithAssistanceDTO>>> GetAllWalkAssistanceRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllWalkAssistanceRecordsByPatientId(patientId));
            return await response.ToResult<List<WalkWithAssistanceDTO>>(); throw new NotImplementedException();
        }

        public async Task<IResult<List<WoundCareDTO>>> GetAllWoundCareRecordsByPatientId(int patientId)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAllWoundCareRecordsByPatientId(patientId));
            return await response.ToResult<List<WoundCareDTO>>(); throw new NotImplementedException();
        }



        public async Task<IResult<AssistIntoChairDTO>> GetAssistInChairRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetAssistInChairRecordByPatientId(id));
            return await response.ToResult<AssistIntoChairDTO>();
        }

        public async Task<IResult<BedBathAssistDTO>> GetBedBathAssistByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetBedBathAssistByPatientId(id));
            return await response.ToResult<BedBathAssistDTO>();
        }

        public async Task<IResult<BedBathDTO>> GetBedBathPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetBedBathPatientId(id));
            return await response.ToResult<BedBathDTO>();
        }

        public async Task<IResult<BedRestDTO>> GetBedRestRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetBedRestRecordByPatientId(id));
            return await response.ToResult<BedRestDTO>();
        }

        public async Task<IResult<BloodDTO>> GetBloodFrequencyRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetBloodFrequencyRecordByPatientId(id));
            return await response.ToResult<BloodDTO>();
        }

        public async Task<IResult<BloodGlucoseDTO>> GetBloodGlucoseRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetBloodGlucoseRecordByPatientId(id));
            return await response.ToResult<BloodGlucoseDTO>();
        }

        public async Task<IResult<CathetherDTO>> GetCathetherRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetCathetherRecordByPatientId(id));
            return await response.ToResult<CathetherDTO>();
        }

        public async Task<IResult<CheckIDBandDTO>> GetCheckIDBandRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetCheckIDBandRecordByPatientId(id));
            return await response.ToResult<CheckIDBandDTO>();
        }

        public async Task<IResult<ComfortSleepReportDTO>> GetComfortSleepRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetCheckIDBandRecordByPatientId(id));
            return await response.ToResult<ComfortSleepReportDTO>();
        }

        public async Task<IResult<CommunicationDTO>> GetCommunicationRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetCommunicationRecordByPatientId(id));
            return await response.ToResult<CommunicationDTO>();
        }

        public async Task<IResult<ContinentDTO>> GetContinentByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetContinentByPatientId(id));
            return await response.ToResult<ContinentDTO>();
        }

        public async Task<IResult<CotsideDTO>> GetCotsideByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetCotsideByPatientId(id));
            return await response.ToResult<CotsideDTO>();
        }

        public async Task<IResult<DailyCareRecordDTO>> GetDailyCareRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetDailyCareRecordByPatientId(id));
            return await response.ToResult<DailyCareRecordDTO>(); ;
        }

        public async Task<IResult<ExerciseDTO>> GetExerciseRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetExerciseRecordByPatientId(id));
            return await response.ToResult<ExerciseDTO>();
        }

        public async Task<IResult<FullWardDietDTO>> GetFullWardDietByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetFullWardDietByPatientId(id));
            return await response.ToResult<FullWardDietDTO>();
        }

        public async Task<IResult<HealthEducationDTO>> GetHealthEducationByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetHealthEducationByPatientId(id));
            return await response.ToResult<HealthEducationDTO>();
        }

        public async Task<IResult<InhalaNebsDTO>> GetInhalaRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetInhalaRecordByPatientId(id));
            return await response.ToResult<InhalaNebsDTO>(); throw new NotImplementedException();
        }

        public async Task<IResult<IsolationDTO>> GetIsolationRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetIsolationRecordByPatientId(id));
            return await response.ToResult<IsolationDTO>();
        }

        public async Task<IResult<FluidBalanceIVCheckDTO>> GetIVCheckByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetIVCheckByPatientId(id));
            return await response.ToResult<FluidBalanceIVCheckDTO>();
        }

        public async Task<IResult<MaskDTO>> GetMaskRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetMaskRecordByPatientId(id));
            return await response.ToResult<MaskDTO>();
        }

        public async Task<IResult<MedicationDTO>> GetMedicationRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetMedicationRecordByPatientId(id));
            return await response.ToResult<MedicationDTO>();
        }

        public async Task<IResult<MobileImmobileDTO>> GetMobilityRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetMobilityRecordByPatientId(id));
            return await response.ToResult<MobileImmobileDTO>();
        }

        public async Task<IResult<NasalCannulaDTO>> GetNassalCannulByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetNassalCannulByPatientId(id));
            return await response.ToResult<NasalCannulaDTO>();
        }

        public async Task<IResult<NeuroLogicalDTO>> GetNeuroLogicalRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetNeuroLogicalRecordByPatientId(id));
            return await response.ToResult<NeuroLogicalDTO>();
        }

        public async Task<IResult<NeuroVascularDTO>> GetNeuroVascularRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetNeuroVascularRecordByPatientId(id));
            return await response.ToResult<NeuroVascularDTO>();
        }

        public async Task<IResult<KeepNPODTO>> GetNPORecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetNPORecordByPatientId(id));
            return await response.ToResult<KeepNPODTO>();
        }

        public async Task<IResult<OralIntakeDTO>> GetOralCheckByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetOralCheckByPatientId(id));
            return await response.ToResult<OralIntakeDTO>(); //
        }

        public async Task<IResult<PolyMaskDTO>> GetPolyMaskRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetPolyMaskRecordByPatientId(id));
            return await response.ToResult<PolyMaskDTO>();
        }

        public async Task<IResult<PostOperativeCareDTO>> GetPostOperativeRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetPostOperativeRecordByPatientId(id));
            return await response.ToResult<PostOperativeCareDTO>();
        }

        public async Task<IResult<PressurePartCareDTO>> GetPressurePartTimeRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetPressurePartTimeRecordByPatientId(id));
            return await response.ToResult<PressurePartCareDTO>(); throw new NotImplementedException();
        }

        public async Task<IResult<ProgressReportDTO>> GetProgressReportByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetProgressReportByPatientId(id));
            return await response.ToResult<ProgressReportDTO>();
        }

        public async Task<IResult<RednessDTO>> GetRednessRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetRednessRecordByPatientId(id));
            return await response.ToResult<RednessDTO>(); throw new NotImplementedException();
        }

        public async Task<IResult<SelfCareDTO>> GetSelfCareRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetSelfCareRecordByPatientId(id));
            return await response.ToResult<SelfCareDTO>();
        }

        public async Task<IResult<SkinReportDTO>> GetSkinReportByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetSkinReportByPatientId(id));
            return await response.ToResult<SkinReportDTO>();
        }

        public async Task<IResult<SpecialDTO>> GetSpecialRecordPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetSpecialRecordPatientId(id));
            return await response.ToResult<SpecialDTO>();
        }

        public async Task<IResult<StoolChartDTO>> GetStoolChartByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetStoolChartByPatientId(id));
            return await response.ToResult<StoolChartDTO>();
        }

        public Task<IResult<StoolChartDTO>> GetStoolChartByPatientIdQuery(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult<SupportDTO>> GetSupportRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetSupportRecordByPatientId(id));
            return await response.ToResult<SupportDTO>();
        }

        public async Task<IResult<TractionDTO>> GetTractionByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetTractionByPatientId(id));
            return await response.ToResult<TractionDTO>();
        }

        public async Task<IResult<UrineTestDTO>> GetUrineTestByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetUrineTestByPatientId(id));
            return await response.ToResult<UrineTestDTO>();
        }

        public async Task<IResult<VitalSignDTO>> GetVitalSignRecordByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetVitalSignRecordByPatientId(id));
            return await response.ToResult<VitalSignDTO>(); throw new NotImplementedException();
        }

        public async Task<IResult<WalkWithAssistanceDTO>> GetWalkAssistanceByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetWalkAssistanceByPatientId(id));
            return await response.ToResult<WalkWithAssistanceDTO>(); throw new NotImplementedException();
        }

        public async Task<IResult<WoundCareDTO>> GetWoundCareByPatientId(int id)
        {
            await ConfigureHeaders();
            var response = await _httpClient.GetAsync(Routes.PatientRecordsEndpoints.GetWoundCareByPatientId(id));
            return await response.ToResult<WoundCareDTO>();
        }
    }
}
