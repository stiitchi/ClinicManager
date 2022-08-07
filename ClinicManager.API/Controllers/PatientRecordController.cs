using ClinicManager.Application.Modules.PatientRecords.ComfortSleep.Commands;
using ClinicManager.Application.Modules.PatientRecords.ComfortSleep.Queries;
using ClinicManager.Application.Modules.PatientRecords.DailyRecord.Commands;
using ClinicManager.Application.Modules.PatientRecords.DailyRecord.Queries;
using ClinicManager.Application.Modules.PatientRecords.Elimination.Commands;
using ClinicManager.Application.Modules.PatientRecords.Elimination.Queries;
using ClinicManager.Application.Modules.PatientRecords.FluidBalance.Commands;
using ClinicManager.Application.Modules.PatientRecords.FluidBalance.Queries;
using ClinicManager.Application.Modules.PatientRecords.Hygiene.Commands;
using ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries;
using ClinicManager.Application.Modules.PatientRecords.Intervention.Commands;
using ClinicManager.Application.Modules.PatientRecords.Intervention.Queries;
using ClinicManager.Application.Modules.PatientRecords.Mobility.Commands;
using ClinicManager.Application.Modules.PatientRecords.Mobility.Queries;
using ClinicManager.Application.Modules.PatientRecords.Nutrition.Commands;
using ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries;
using ClinicManager.Application.Modules.PatientRecords.Observation.Commands;
using ClinicManager.Application.Modules.PatientRecords.Observation.Queries;
using ClinicManager.Application.Modules.PatientRecords.Oxygenation.Commands;
using ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries;
using ClinicManager.Application.Modules.PatientRecords.Prescription.Commands;
using ClinicManager.Application.Modules.PatientRecords.Prescription.Queries;
using ClinicManager.Application.Modules.PatientRecords.ProgressReport.Commands;
using ClinicManager.Application.Modules.PatientRecords.ProgressReport.Queries;
using ClinicManager.Application.Modules.PatientRecords.Psychological.Commands;
using ClinicManager.Application.Modules.PatientRecords.Psychological.Queries;
using ClinicManager.Application.Modules.PatientRecords.Safety.Commands;
using ClinicManager.Application.Modules.PatientRecords.Safety.Queries;
using ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Commands;
using ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Queries;
using ClinicManager.Application.Modules.PatientRecords.SkinReport.Commands;
using ClinicManager.Application.Modules.PatientRecords.SkinReport.Queries;
using ClinicManager.Application.Modules.PatientRecords.StoolChart.Commands;
using ClinicManager.Application.Modules.PatientRecords.StoolChart.Queries;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.DTO_s.Records.Elimination;
using ClinicManager.Shared.DTO_s.Records.FluidBalance;
using ClinicManager.Shared.DTO_s.Records.Hygiene;
using ClinicManager.Shared.DTO_s.Records.Intervention;
using ClinicManager.Shared.DTO_s.Records.Mobility;
using ClinicManager.Shared.DTO_s.Records.Nutrition;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.DTO_s.Records.Oxygenation;
using ClinicManager.Shared.DTO_s.Records.Prescription;
using ClinicManager.Shared.DTO_s.Records.Psychological;
using ClinicManager.Shared.DTO_s.Records.Safety;
using ClinicManager.Shared.DTO_s.Records.SkinIntegrity;
using ClinicManager.Shared.DTO_s.Records.SkinReport;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRecordController : BaseApiController<PatientRecordController>
    {
                                            /* Add Records */

        [HttpPost("AddPrescription")]
        public async Task<IActionResult> AddPrescription(PrescriptionDTO prescription)
        {
            return Ok(await _mediator.Send(new AddPrescriptionCommand
            {
                PrescriptionId  = prescription.PrescriptionId,
                Date  = prescription.Date,
                MedicationName = prescription.MedicationName,
                Dose = prescription.Dose,
                Route = prescription.Route,
                Freq = prescription.Freq,
                DurationOfQuantity = prescription.DurationOfQuantity,
                ReqWS = prescription.ReqWS,
                ReqQuantity = prescription.ReqQuantity,
                ReqDate = prescription.ReqDate,
                PharQuantity = prescription.PharQuantity,
                PharDate = prescription.PharDate,
                PatientId = prescription.PatientId
            }));
        }

        //Comfort Sleep

        [HttpPost("AddComfortSleepRecord")]
        public async Task<IActionResult> AddComfortSleepRecord(ComfortSleepReportDTO sleepReport)
        {
            return Ok(await _mediator.Send(new AddComfortSleepRecordCommand
            {
               ComfortSleepRecordId = sleepReport.ComfortSleepRecordId,
               Frequency = sleepReport.Frequency, 
               PainControlTime = sleepReport.PainControlDateTime, 
               Signature = sleepReport.Signature,
               PatientId = sleepReport.PatientId
            }));
        }

        //Daily Care

        [HttpPost("AddDailyCareRecord")]
        public async Task<IActionResult> AddDailyCareRecord(DailyCareRecordDTO dailyCare)
        {
            return Ok(await _mediator.Send(new AddDailyCareRecordCommand
            {
                DailyCareRecordId = dailyCare.DailyCareRecordId,
                CareRecord = dailyCare.CareRecord,
                DateAdded = dailyCare.DateAdded,
                TimeAdded = dailyCare.TimeAdded,
                PatientId = dailyCare.PatientId
            }));
        }

        //Elimination

        [HttpPost("AddCathetherRecord")]
        public async Task<IActionResult> AddCathetherRecord(CathetherDTO elimination)
        {
            return Ok(await _mediator.Send(new AddCathetherCommand
            {
               CatheterRecordId = elimination.CatheterId,
               CatheterFreq = elimination.CatheterFreq,
               CatheterSignature = elimination.CatheterSignature,
               CatheterTime = elimination.CatheterTime,
               CatheterPatientId = elimination.PatientId
            }));
        }

        [HttpPost("AddContinentRecord")]
        public async Task<IActionResult> AddContinentRecord(ContinentDTO elimination)
        {
            return Ok(await _mediator.Send(new AddContinentCommand
            {
                ContinentId = elimination.ContinentId,
                ContinentFreq = elimination.ContinentFreq,
                ContinentSignature = elimination.ContinentSignature,
                ContinentTime = elimination.ContinentTime,
                PatientId = elimination.PatientId
            }));
        }

        //Fluid Balance

        [HttpPost("Add24HourIntakeRecord")]
        public async Task<IActionResult> Add24HourIntakeRecord(Previous24HourIntakeDTO intake)
        {
            return Ok(await _mediator.Send(new Add24HourIntakeCommand
            {
                TotalIntakeId = intake.TotalIntakeId,
                DateToday = intake.DateToday,
                Intake24Hour = intake.Intake24Hour,
                Output24Hour = intake.Output24Hour,
                TotalIntake = intake.TotalIntake,
                PatientId = intake.PatientId
            }));
        }

        [HttpPost("AddOralOutputRecord")]
        public async Task<IActionResult> AddOralIntakeTestRecord(OralOutputDTO oral)
        {
            return Ok(await _mediator.Send(new AddOralOutputCommand
            {
                OralOutputTestId = oral.OralOutputTestId,
                OralIOutputMl = oral.OralOutputMl,  
                OralOutputTime = oral.OralOutputTime,
                IsUrine = oral.IsUrine,
                RunningTotalOralOutput = oral.RunningOutputTotal,
                PatientId = oral.PatientId
            }));
        }

        [HttpPost("AddOralInputRecord")]
        public async Task<IActionResult> AddOralInputRecord(OralIntakeDTO oral)
        {
            return Ok(await _mediator.Send(new AddOralIntakeTestCommand
            {
                OralIntakeId = oral.OralIntakeTestId,
                OralIntakeMl = oral.OralIntakeMl,
                OralIntakeVolume = oral.OralIntakeVolume,
                OralIntakeTime = oral.OralIntakeTime,
                OralCheckType = oral.OralCheckType,
                RunningTotalOral = oral.RunningIntakeTotal,
                PatientId = oral.PatientId
            }));
        }

        [HttpPost("AddIVTestRecord")]
        public async Task<IActionResult> AddIVTestRecord(FluidBalanceIVCheckDTO ivCheck)
        {
            return Ok(await _mediator.Send(new AddIVTestCommand
            {
                IVTestId = ivCheck.IVTestId,
                intravenousCheck = ivCheck.intravenousCheck,
                intravenousCheckType = ivCheck.intravenousCheckType,
                intravenousCompleteVolume = ivCheck.intravenousCompleteVolume,
                intravenousDesc = ivCheck.intravenousDesc,
                intravenousIntakeTime = ivCheck.intravenousIntakeTime,
                intravenousIntakeTimeCompleted = ivCheck.intravenousIntakeTimeCompleted,
                intravenousML = ivCheck.intravenousML,
                intravenousRunningTotal = ivCheck.intravenousRunningTotal,
                intravenousStartVolume = ivCheck.intravenousStartVolume,
                PatientId = ivCheck.PatientId
            }));
        }

        //Hygiene

        [HttpPost("AddBedBathAssist")]
        public async Task<IActionResult> AddBedBathAssist(BedBathAssistDTO hygiene)
        {
            return Ok(await _mediator.Send(new AddBedBathAssistCommand
            {
                BedBathAssistId = hygiene.BedBathAssistId,
                BedBathAssistFreq = hygiene.BedBathAssistFreq, 
                BedBathAssistSignature = hygiene.BedBathAssistSignature,
                BedBathAssistTime = hygiene.BedBathAssistTime,
                PatientId = hygiene.PatientId
            }));
        }

        [HttpPost("AddBedBathRecord")]
        public async Task<IActionResult> AddBedBathRecord(BedBathDTO hygiene)
        {
            return Ok(await _mediator.Send(new AddBedBathRecordCommand
            {
                BedBathId = hygiene.BedBathId,
                BedBathFreq = hygiene.BedBathFreq, 
                BedBathSignature = hygiene.BedBathSignature,
                BedBathTime = hygiene.BedBathTime,
                PatientId = hygiene.PatientId
            }));
        }

        [HttpPost("AddSelfCareRecord")]
        public async Task<IActionResult> AddSelfCareRecord(SelfCareDTO hygiene)
        {
            return Ok(await _mediator.Send(new AddSelfCareRecordCommand
            {
                SelfCareId = hygiene.SelfCareId,
                SelfCareFreq = hygiene.SelfCareFreq, 
                SelfCareSignature = hygiene.SelfCareSignature,
                SelfCareTime = hygiene.SelfCareTime,
                PatientId = hygiene.PatientId
            }));
        }

        //Intervention

        [HttpPost("AddIsolationRecord")]
        public async Task<IActionResult> AddIsolationRecord(IsolationDTO isolation)
        {
            return Ok(await _mediator.Send(new AddIsolationCommand
            {
                IsolationId = isolation.IsolationId,
                IsolationFreq = isolation.IsolationFreq, 
                IsolationSignature = isolation.IsolationSignature,
                IsolationTime = isolation.IsolationTime,
                PatientId = isolation.PatientId
            }));
        }

        [HttpPost("AddMedicationRecord")]
        public async Task<IActionResult> AddMedicationRecord(MedicationDTO medication)
        {
            return Ok(await _mediator.Send(new AddMedicationCommand
            {
                MedicationId = medication.MedicationId,
                MedicationFreq = medication.MedicationFreq, 
                MedicationSignature = medication.MedicationSignature,
                MedicationTime = medication.MedicationTime,
                PatientId = medication.PatientId
            }));
        }

        [HttpPost("AddPostOperativeCareRecord")]
        public async Task<IActionResult> AddPostOperativeCareRecord(PostOperativeCareDTO operativeCare)
        {
            return Ok(await _mediator.Send(new AddPostOperativeCareCommand
            {
                PostOperativeCareId = operativeCare.PostOperativeCareId,
                PostOperativeCareFreq = operativeCare.PostOperativeCareFreq,
                PostOperativeCareSignature = operativeCare.PostOperativeCareSignature,
                PostOperativeCareTime = operativeCare.PostOperativeCareTime,
                PatientId = operativeCare.PatientId
            }));
        }

        [HttpPost("AddTractionRecord")]
        public async Task<IActionResult> AddTractionRecord(TractionDTO traction)
        {
            return Ok(await _mediator.Send(new AddTractionCommand
            {
                TractionId = traction.TractionId,
                TractionFreq = traction.TractionFreq,
                TractionSignature = traction.TractionSignature,
                TractionTime = traction.TractionTime,
                PatientId = traction.PatientId
            }));
        }

        [HttpPost("AddWoundCareRecord")]
        public async Task<IActionResult> AddWoundCareRecord(WoundCareDTO woundCare)
        {
            return Ok(await _mediator.Send(new AddWoundCareCommand
            {
                WoundCareId = woundCare.WoundCareId,  
                WoundCareFreq = woundCare.WoundCareFreq,
                WoundCareSignature = woundCare.WoundCareSignature,
                WoundCareTime = woundCare.WoundCareTime,
                PatientId = woundCare.PatientId
            }));
        }

        //Mobility

        [HttpPost("AddAssistInChairRecord")]
        public async Task<IActionResult> AddAssistInChairRecord(AssistIntoChairDTO mobility)
        {
            return Ok(await _mediator.Send(new AddAssistInChairCommand
            {
                AssistIntoChairId = mobility.AssistIntoChairId,
                AssistIntoChairFrequency = mobility.AssistIntoChairFrequency,
                AssistIntoChairSignature = mobility.AssistIntoChairSignature,
                AssistIntoChairTime = mobility.AssistIntoChairTime,
                PatientId = mobility.PatientId
            }));
        }

        [HttpPost("AddBedRestRecord")]
        public async Task<IActionResult> AddBedRestRecord(BedRestDTO mobility)
        {
            return Ok(await _mediator.Send(new AddBedRestCommand
            {   
                BedRestId = mobility.BedRestId,
                BedRestFrequency = mobility.BedRestFrequency,
                BedRestSignature = mobility.BedRestSignature,
                BedRestTime = mobility.BedRestTime,
                PatientId = mobility.PatientId
            }));
        }

        [HttpPost("AddExerciseRecord")]
        public async Task<IActionResult> AddExerciseRecord(ExerciseDTO mobility)
        {
            return Ok(await _mediator.Send(new AddExerciseCommand
            {
                ExercisesId = mobility.ExercisesId,
                ExercisesFrequency = mobility.ExercisesFrequency,
                ExercisesSignature = mobility.ExercisesSignature,
                ExercisesTime = mobility.ExercisesTime,
                PatientId = mobility.PatientId
            }));
        }

        [HttpPost("AddMobileImmobileRecord")]
        public async Task<IActionResult> AddMobileImmobileRecord(MobileImmobileDTO mobility)
        {
            return Ok(await _mediator.Send(new AddMobileImmobileCommand
            {
                MobileImmobileId = mobility.MobileImmobileId,
                MobileImmobileFreq = mobility.MobileImmobileFreq,
                MobileImmobileSignature = mobility.MobileImmobileSignature,
                MobileImmobileTime = mobility.MobileImmobileTime,
                PatientId = mobility.PatientId
            }));
        }

        [HttpPost("AddWalkAssistanceRecord")]
        public async Task<IActionResult> AddWalkAssistanceRecord(WalkWithAssistanceDTO mobility)
        {
            return Ok(await _mediator.Send(new AddWalkAssistanceCommand
            {
                WalkWithAssistanceId = mobility.WalkWithAssistanceId,
                WalkWithAssistanceFrequency = mobility.WalkWithAssistanceFrequency,
                WalkWithAssistanceSignature = mobility.WalkWithAssistanceSignature,
                WalkWithAssistanceTime = mobility.WalkWithAssistanceTime,
                PatientId = mobility.PatientId
            }));
        }

        //Nutrition

        [HttpPost("AddFullWardDietRecord")]
        public async Task<IActionResult> AddFullWardDietRecord(FullWardDietDTO nutrition)
        {
            return Ok(await _mediator.Send(new AddFullWardDietCommand
            {
                FullWardDietId = nutrition.FullWardDietID,
                FullWardDietFrequency = nutrition.FullWardDietFrequency,
                FullWardDietSignature = nutrition.FullWardDietSignature,
                FullWardDietTime = nutrition.FullWardDietTime,
                PatientId = nutrition.PatientId
            }));
        }

        [HttpPost("AddNPORecord")]
        public async Task<IActionResult> AddNPORecord(KeepNPODTO nutrition)
        {
            return Ok(await _mediator.Send(new AddNPORecordCommand
            {
                KeepNPOId = nutrition.KeepNPOId,
                KeepNPOFrequency = nutrition.KeepNPOFrequency,
                KeepNPOSignature = nutrition.KeepNPOSignature,
                KeepNPOTime = nutrition.KeepNPOTime,
                PatientId = nutrition.PatientId
            }));
        }

        [HttpPost("AddSpecialRecord")]
        public async Task<IActionResult> AddSpecialRecord(SpecialDTO nutrition)
        {
            return Ok(await _mediator.Send(new AddSpecialRecordCommand
            {
                SpecialId = nutrition.SpecialId,
                SpecialFrequency = nutrition.SpecialFrequency,
                SpecialSignature = nutrition.SpecialSignature,
                SpecialTime = nutrition.SpecialTime,
                PatientId = nutrition.PatientId
            }));
        }

        //Observation

        [HttpPost("AddBloodFrequencyRecord")]
        public async Task<IActionResult> AddBloodFrequencyRecord(BloodDTO observation)
        {
            return Ok(await _mediator.Send(new AddBloodFrequencyCommand
            {
                BloodId = observation.BloodId,
                BloodFrequency = observation.BloodFrequency,
                BloodSignature = observation.BloodSignature,
                BloodTime = observation.BloodTime,
                PatientId = observation.PatientId
            }));
        }

        [HttpPost("AddBloodGlucoseRecord")]
        public async Task<IActionResult> AddBloodGlucoseRecord(BloodGlucoseDTO observation)
        {
            return Ok(await _mediator.Send(new AddBloodGlucoseCommand
            {
                BloodGlucoseId = observation.BloodGlucoseId,
                BloodGlucoseFrequency = observation.BloodGlucoseFrequency,
                BloodGlucoseSignature = observation.BloodGlucoseSignature,
                BloodGlucoseTime = observation.BloodGlucoseTime,
                PatientId = observation.PatientId
            }));
        }

        [HttpPost("AddNeuroLogicalRecord")]
        public async Task<IActionResult> AddNeuroLogicalRecord(NeuroLogicalDTO observation)
        {
            return Ok(await _mediator.Send(new AddNeuroLogicalCommand
            {
                NeuroLogicalId = observation.NeuroLogicalId,
                NeuroLogicalFrequency = observation.NeuroLogicalFrequency,
                NeuroLogicalSignature = observation.NeuroLogicalSignature,
                NeuroLogicalTime = observation.NeuroLogicalTime,
                PatientId = observation.PatientId
            }));
        }

        [HttpPost("AddNeuroVascularRecord")]
        public async Task<IActionResult> AddNeuroVascularRecord(NeuroVascularDTO observation)
        {
            return Ok(await _mediator.Send(new AddNeuroVascularCommand
            {
                NeuroVascularId = observation.NeuroVascularId,
                NeuroVascularFrequency = observation.NeuroVascularFrequency,
                NeuroVascularSignature = observation.NeuroVascularSignature,
                NeuroVascularTime = observation.NeuroVascularTime,
                PatientId = observation.PatientId
            }));
        }

        [HttpPost("AddUrineTestRecord")]
        public async Task<IActionResult> AddUrineTestRecord(UrineTestDTO observation)
        {
            return Ok(await _mediator.Send(new AddUrineTestCommand
            {
                UrineTestId = observation.UrineTestId,
                UrineTestFrequency = observation.UrineTestFrequency,
                UrineTestSignature = observation.UrineTestSignature,
                UrineTestTime = observation.UrineTestTime,
                PatientId = observation.PatientId
            }));
        }

        [HttpPost("AddVitalSignRecord")]
        public async Task<IActionResult> AddVitalSignRecord(VitalSignDTO observation)
        {
            return Ok(await _mediator.Send(new AddVitalSignCommands
            {
                VitalSignsId = observation.VitalSignsId,
                VitalSignsFrequency = observation.VitalSignsFrequency,
                VitalSignSignature = observation.VitalSignSignature,
                VitalSignsTime = observation.VitalSignsTime,
                PatientId = observation.PatientId
            }));
        }

        //Oxygenation

        [HttpPost("AddInhalaNebsRecord")]
        public async Task<IActionResult> AddInhalaNebsRecord(InhalaNebsDTO oxygenation)
        {
            return Ok(await _mediator.Send(new AddInhalaNebsCommand
            {
                InhalaNebsId = oxygenation.InhalaNebsId,
                InhalaNebsFrequency = oxygenation.InhalaNebsFrequency, 
                InhalaNebsSignature = oxygenation.InhalaNebsSignature,
                InhalaNebsTime = oxygenation.InhalaNebsTime,
                PatientId = oxygenation.PatientId
            }));
        }

        [HttpPost("AddMaskTimeRecord")]
        public async Task<IActionResult> AddMaskTimeRecord(MaskDTO oxygenation)
        {
            return Ok(await _mediator.Send(new AddMaskTimeCommand
            {
                MaskId = oxygenation.MaskId,    
                MaskFrequency = oxygenation.MaskFrequency,
                MaskSignature = oxygenation.MaskSignature,
                MaskTime = oxygenation.MaskTime,
                PatientId = oxygenation.PatientId
            }));
        }

        [HttpPost("AddNasalCannulRecord")]
        public async Task<IActionResult> AddNasalCannulRecord(NasalCannulaDTO oxygenation)
        {
            return Ok(await _mediator.Send(new AddNasalCannulCommand
            {
                NasalCannulaId = oxygenation.NasalCannulaId,
                NasalCannulaFrequency = oxygenation.NasalCannulaFrequency,
                NasalCannulaSignature = oxygenation.NasalCannulaSignature,
                NasalCannulaTime = oxygenation.NasalCannulaTime,
                PatientId = oxygenation.PatientId
            }));
        }

        [HttpPost("AddPolyMaskRecord")]
        public async Task<IActionResult> AddPolyMaskRecord(PolyMaskDTO oxygenation)
        {
            return Ok(await _mediator.Send(new AddPolyMaskCommand
            {
                PolyMaskId = oxygenation.PolyMaskId,
                PolyMaskFrequency = oxygenation.PolyMaskFrequency,
                PolyMaskSignature = oxygenation.PolyMaskSignature,
                PolyMaskTime = oxygenation.PolyMaskTime,
                PatientId = oxygenation.PatientId
            }));
        }

        //Progress Report

        [HttpPost("AddProgressReportRecord")]
        public async Task<IActionResult> AddProgressReportRecord(ProgressReportDTO report)
        {
            return Ok(await _mediator.Send(new AddProgressReportCommand
            {
                ProgressReportId = report.ProgressReportId,
                Allergy = report.Allergy,
                DateAdded = report.DateAdded,
                Desc = report.Desc,
                RiskFactor = report.RiskFactor,
                TimeAdded = report.TimeAdded,
                PatientId = report.PatientId
            }));
        }

        //Psychological 

        [HttpPost("AddCommunicationRecord")]
        public async Task<IActionResult> AddCommunicationRecord(CommunicationDTO psychologicalRecord)
        {
            return Ok(await _mediator.Send(new AddCommunicationCommand
            {
                CommunicationId = psychologicalRecord.CommunicationId,  
                CommunicationFrequency = psychologicalRecord.CommunicationFrequency,
                CommunicationSignature = psychologicalRecord.CommunicationSignature,
                CommunicationTime = psychologicalRecord.CommunicationTime,
                PatientId = psychologicalRecord.PatientId
            }));
        }

        [HttpPost("AddHealthEducationRecord")]
        public async Task<IActionResult> AddHealthEducationRecord(HealthEducationDTO psychologicalRecord)
        {
            return Ok(await _mediator.Send(new AddHealthEducationCommand
            {
                HealthEducationId = psychologicalRecord.HealthEducationId,
                HealthEducationFrequency = psychologicalRecord.HealthEducationFrequency,
                HealthEducationSignature = psychologicalRecord.HealthEducationSignature,
                HealthEducationTime = psychologicalRecord.HealthEducationTime,
                PatientId = psychologicalRecord.PatientId
            }));
        }

        [HttpPost("AddSupportRecord")]
        public async Task<IActionResult> AddSupportRecord(SupportDTO psychologicalRecord)
        {
            return Ok(await _mediator.Send(new AddSupportCommand
            {
                SupportId = psychologicalRecord.SupportId,
                SupportFrequency = psychologicalRecord.SupportFrequency,
                SupportSignature = psychologicalRecord.SupportSignature,
                SupportTime = psychologicalRecord.SupportTime,
                PatientId = psychologicalRecord.PatientId
            }));
        }

        //Safety

        [HttpPost("AddCheckIDBandsRecord")]
        public async Task<IActionResult> AddCheckIDBandsRecord(CheckIDBandDTO safety)
        {
            return Ok(await _mediator.Send(new AddCheckIDBandsCommand
            {
                CheckIDBandsId = safety.CheckIDBandsId, 
                CheckIDBandsFrequency = safety.CheckIDBandsFrequency,
                CheckIDBandsSignature = safety.CheckIDBandsSignature,
                CheckIDBandsTime = safety.CheckIDBandsTime,
                PatientId = safety.PatientId
            }));
        }

        [HttpPost("AddCotsideRecord")]
        public async Task<IActionResult> AddCotsideRecord(CotsideDTO safety)
        {
            return Ok(await _mediator.Send(new AddCotsideCommand
            {
                CotsidesId = safety.CotsidesId, 
                CotsidesFrequency = safety.CotsidesFrequency,
                CotsidesSignature = safety.CotsidesSignature,
                CotsidesTime = safety.CotsidesTime,
                PatientId = safety.PatientId
            }));
        }

        //Skin Report

        [HttpPost("AddSkinIntegrityReportRecord")]
        public async Task<IActionResult> AddSkinIntegrityReportRecord(SkinReportDTO skin)
        {
            return Ok(await _mediator.Send(new AddSkinIntegrityReportCommand
            {
                SkinIntegrityId = skin.SkinIntegrityId,
                Comments = skin.Comments,
                Heals = skin.HealsDescription,
                Hips = skin.HipsDescription,
                Other = skin.OtherDescription,
                Sacrum = skin.SacrumDescription,
                PatientId = skin.PatientId
            }));
        }

        //Skin Integrity Report

        [HttpPost("AddPressurePartCareTimeRecord")]
        public async Task<IActionResult> AddPressurePartCareTimeRecord(PressurePartCareDTO skin)
        {
            return Ok(await _mediator.Send(new AddPressurePartCareTimeCommand
            {
                PressurePartCareId = skin.PressurePartCareId,
                PressurePartCareSignature = skin.PressurePartCareSignature,
                PressurePartCareFrequency = skin.PressurePartCareFrequency,
                PressurePartCareTime = skin.PressurePartCareTime,
                PatientId = skin.PatientId
            }));
        }

        [HttpPost("AddRednessReportRecord")]
        public async Task<IActionResult> AddRednessReportRecord(RednessDTO skin)
        {
            return Ok(await _mediator.Send(new AddRednessReportCommand
            {
                ReportRednessId = skin.ReportRednessId,
                ReportRednessFrequency = skin.ReportRednessFrequency,
                ReportRednessSignature = skin.ReportRednessSignature,
                ReportRednessTime = skin.ReportRednessTime,
                PatientId = skin.PatientId
            }));
        }

        //Stool Chart Report

        [HttpPost("AddStoolChartRecord")]
        public async Task<IActionResult> AddStoolChartRecord(StoolChartDTO stoolChart)
        {
            return Ok(await _mediator.Send(new AddStoolChartCommand
            {
                StoolChartId = stoolChart.StoolChartId,
                BowelAmount = stoolChart.BowelAmount,
                StoolTime = stoolChart.StoolTime,
                Blood = stoolChart.Blood,
                StoolColour = stoolChart.StoolColour,         
                Consistency = stoolChart.Consistency,
                MuscousAmount = stoolChart.MuscousAmount,
                NormalBowelMovement = stoolChart.NormalBowelMovement,
                StoolDate = stoolChart.StoolDate,
                PatientId = stoolChart.PatientId
            }));
        }

                                            /* Delete Records */

        [HttpDelete("DeletePrescription")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            return Ok(await _mediator.Send(new DeletePrescriptionCommand { Id = id }));
        }

        //Comfort Sleep

        [HttpDelete("DeleteComfortSleepRecord")]
        public async Task<IActionResult> DeleteComfortSleepRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteComfortSleepRecordCommand { Id = id }));
        }

        //Daily Care

        [HttpDelete("DeleteDailyCareRecord")]
        public async Task<IActionResult> DeleteDailyCareRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteDailyCareRecordCommand { Id = id }));
        }

        //Elimination

        [HttpDelete("DeleteCathetherRecord")]
        public async Task<IActionResult> DeleteCathetherRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteCathetherCommand { Id = id }));
        }

        [HttpDelete("DeleteContinentRecord")]
        public async Task<IActionResult> DeleteContinentRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteContinentCommand { Id = id }));
        }

        //Fluid Balance

        [HttpDelete("Delete24HourCheckRecord")]
        public async Task<IActionResult> Delete24HourCheckRecord(int id)
        {
            return Ok(await _mediator.Send(new Delete24HourIntakeCommand { Id = id }));
        }

        [HttpDelete("DeleteIVCheckRecord")]
        public async Task<IActionResult> DeleteIVCheckRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteIVTestCommand { Id = id }));
        }

        [HttpDelete("DeleteOralOutputRecord")]
        public async Task<IActionResult> DeleteOralOutputRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteOralOutputTestCommand { Id = id }));
        }

        [HttpDelete("DeleteOralInputRecord")]
        public async Task<IActionResult> DeleteOralInputRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteOralInputTestCommand { Id = id }));
        }

        //Hygiene

        [HttpDelete("DeleteBedBathAssistRecord")]
        public async Task<IActionResult> DeleteBedBathAssistRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteBedBathAssistCommand { Id = id }));
        }

        [HttpDelete("DeleteBedBathRecord")]
        public async Task<IActionResult> DeleteBedBathRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteBedBathRecordCommand { Id = id }));
        }

        [HttpDelete("DeleteSelfCareRecord")]
        public async Task<IActionResult> DeleteSelfCareRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteSelfCareRecordCommand { Id = id }));
        }

        //Intervention

        [HttpDelete("DeleteIsolationRecord")]
        public async Task<IActionResult> DeleteIsolationRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteIsolationCommand { Id = id }));
        }

        [HttpDelete("DeleteMedicationRecord")]
        public async Task<IActionResult> DeleteMedicationRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteMedicationCommand { Id = id }));
        }

        [HttpDelete("DeletePostOperativeCareRecord")]
        public async Task<IActionResult> DeletePostOperativeCareRecord(int id)
        {
            return Ok(await _mediator.Send(new DeletePostOperativeCareCommand { Id = id }));
        }

        [HttpDelete("DeleteTractionRecord")]
        public async Task<IActionResult> DeleteTractionRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteTractionCommand { Id = id }));
        }

        [HttpDelete("DeleteWoundCareRecord")]
        public async Task<IActionResult> DeleteWoundCareRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteWoundCareCommand { Id = id }));
        }

        //Mobility

        [HttpDelete("DeleteAssistInChairRecord")]
        public async Task<IActionResult> DeleteAssistInChairRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteAssistInChairCommand { Id = id }));
        }

        [HttpDelete("DeleteBedRestRecord")]
        public async Task<IActionResult> DeleteBedRestRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteBedRestCommand { Id = id }));
        }

        [HttpDelete("DeleteExerciseRecord")]
        public async Task<IActionResult> DeleteExerciseRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteExerciseEntryCommand { Id = id }));
        }

        [HttpDelete("DeleteMobileImmobileRecord")]
        public async Task<IActionResult> DeleteMobileImmobileRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteMobileImmobileCommand { Id = id }));
        }

        [HttpDelete("DeleteWalkAssistanceRecord")]
        public async Task<IActionResult> DeleteWalkAssistanceRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteWalkAssistanceCommand { Id = id }));
        }

        //Nutrition

        [HttpDelete("DeleteFullWardDietRecord")]
        public async Task<IActionResult> DeleteFullWardDietRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteFullWardDietCommand { Id = id }));
        }

        [HttpDelete("DeleteNPORecord")]
        public async Task<IActionResult> DeleteNPORecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteNPORecordCommand { Id = id }));
        }

        [HttpDelete("DeleteSpecialRecord")]
        public async Task<IActionResult> DeleteSpecialRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteSpecialRecordCommand { Id = id }));
        }

        //Observation

        [HttpDelete("DeleteBloodFrequencyRecord")]
        public async Task<IActionResult> DeleteBloodFrequencyRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteBloodFrequencyCommand { Id = id }));
        }

        [HttpDelete("DeleteBloodGlucoseRecord")]
        public async Task<IActionResult> DeleteBloodGlucoseRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteBloodGlucoseCommand { Id = id }));
        }

        [HttpDelete("DeleteNeuroLogicalRecord")]
        public async Task<IActionResult> DeleteNeuroLogicalRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteNeuroLogicalCommand { Id = id }));
        }

        [HttpDelete("DeleteNeuroVascularRecord")]
        public async Task<IActionResult> DeleteNeuroVascularRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteNeuroVascularCommand { Id = id }));
        }

        [HttpDelete("DeleteUrineTestRecord")]
        public async Task<IActionResult> DeleteUrineTestRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteUrineTestCommand { Id = id }));
        }

        [HttpDelete("DeleteVitalSignRecord")]
        public async Task<IActionResult> DeleteVitalSignRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteVitalSignCommand { Id = id }));
        }

        //Oxygenation

        [HttpDelete("DeleteInhalaNebsRecord")]
        public async Task<IActionResult> DeleteInhalaNebsRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteInhalaNebsCommand { Id = id }));
        }

        [HttpDelete("DeleteMaskTimeRecord")]
        public async Task<IActionResult> DeleteMaskTimeRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteMaskTimeCommand { Id = id }));
        }

        [HttpDelete("DeleteNasalCannulRecord")]
        public async Task<IActionResult> DeleteNasalCannulRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteNasalCannulCommand { Id = id }));
        }

        [HttpDelete("DeletePolyMaskRecord")]
        public async Task<IActionResult> DeletePolyMaskRecord(int id)
        {
            return Ok(await _mediator.Send(new DeletePolyMaskCommand { Id = id }));
        }

        //Progress Report

        [HttpDelete("DeleteProgressReportRecord")]
        public async Task<IActionResult> DeleteProgressReportRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteProgressReportCommand { Id = id }));
        }

        //Psychological

        [HttpDelete("DeleteHealthEducationRecord")]
        public async Task<IActionResult> DeleteHealthEducationRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteHealthEducationCommand { Id = id }));
        }

        [HttpDelete("DeleteMaskCommunicationRecord")]
        public async Task<IActionResult> DeleteMaskCommunicationRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteMaskCommunicationCommand { Id = id }));
        }

        [HttpDelete("DeleteSupportRecord")]
        public async Task<IActionResult> DeleteSupportRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteSupportCommand { Id = id }));
        }

        //Safety

        [HttpDelete("DeleteCheckIDBandRecord")]
        public async Task<IActionResult> DeleteCheckIDBandRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteCheckIDBandCommand { Id = id }));
        }

        [HttpDelete("DeleteCotsideRecord")]
        public async Task<IActionResult> DeleteCotsideRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteCotsideCommand { Id = id }));
        }

        //Skin Report

        [HttpDelete("DeleteSkinReportRecord")]
        public async Task<IActionResult> DeleteSkinReportRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteSkinReportCommand { Id = id }));
        }

        //Skin Integrity Report

        [HttpDelete("DeletePressurePartCareTimeRecord")]
        public async Task<IActionResult> DeletePressurePartCareTimeRecord(int id)
        {
            return Ok(await _mediator.Send(new DeletePressurePartCareTimeCommand { Id = id }));
        }

        [HttpDelete("DeleteRednessReportRecord")]
        public async Task<IActionResult> DeleteRednessReportRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteRednessReportCommand { Id = id }));
        }

        //Stool Chart

        [HttpDelete("DeleteStoolChartRecord")]
        public async Task<IActionResult> DeleteStoolChartRecord(int id)
        {
            return Ok(await _mediator.Send(new DeleteStoolChartCommand { Id = id }));
        }

                                            /* Get All Records */

        [HttpGet("GetAllPrescriptionsByPatientId")]
        public async Task<IActionResult> GetAllPrescriptionsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllPrescriptionsByPatientIdQuery { PatientId = patientId }));
        }

        //Comfort Sleep
        
        [HttpGet("GetAllComfortSleepRecordsByPatientId")]
        public async Task<IActionResult> GetAllComfortSleepRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllComfortSleepRecordsByPatientIdQuery { PatientId = patientId }));
        }

        //Daily Care

        [HttpGet("GetAllDailyCareRecordsByPatientId")]
        public async Task<IActionResult> GetAllDailyCareRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllDailyRecordsByPatientIdQuery { PatientId = patientId }));
        }

        //Elimination

        [HttpGet("GetAllCathethersByPatientId")]
        public async Task<IActionResult> GetAllCathethersByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllCathethersByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllContinentsByPatientId")]
        public async Task<IActionResult> GetAllContinentsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllContinentsByPatientIdQuery { PatientId = patientId }));
        }

        //Fluid Balance

        [HttpGet("GetAll24HourIntakesByPatientId")]
        public async Task<IActionResult> GetAll24HourIntakesByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAll24HourIntakesByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllOralOutputChecksByPatientId")]
        public async Task<IActionResult> GetAllOralOutputChecksByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllOralOutputChecksByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllOralInputChecksByPatientId")]
        public async Task<IActionResult> GetAllOralInputChecksByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllOralInputChecksByPatentIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllIVCheckByPatientId")]
        public async Task<IActionResult> GetAllIVCheckByPatientId(int patientId)
        { 
            return Ok(await _mediator.Send(new GetAllIVChecksByPatentIdQuery { PatientId = patientId }));
        }

        //Hygiene

        [HttpGet("GetAllBedBathAssistRecordsByPatientId")]
        public async Task<IActionResult> GetAllBedBathAssistRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllBedBathAssistRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllBedBathRecordByPatientId")]
        public async Task<IActionResult> GetAllBedBathRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllBedBathRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllSelfCareRecordsByPatientId")]
        public async Task<IActionResult> GetAllSelfCareRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllSelfCareRecordsByPatientIdQuery { PatientId = patientId }));
        }

        //Intervention

        [HttpGet("GetAllIsolationRecordsByPatientId")]
        public async Task<IActionResult> GetAllIsolationRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllIsolationRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllMedicationRecordsByPatientId")]
        public async Task<IActionResult> GetAllMedicationRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllMedicationRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllPostOperativeCareRecordsByPatientId")]
        public async Task<IActionResult> GetAllPostOperativeCareRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllPostOperativeCareRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllTractionRecordsByPatientId")]
        public async Task<IActionResult> GetAllTractionRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllTractionRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllWoundCareRecordsByPatientId")]
        public async Task<IActionResult> GetAllWoundCareRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllWoundCareRecordsByPatientIdQuery { PatientId = patientId }));
        }

        //Mobility

        [HttpGet("GetAllAssistInChairRecordByPatientId")]
        public async Task<IActionResult> GetAllAssistInChairRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllAssistInChairRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllBedRestRecordsByPatientId")]
        public async Task<IActionResult> GetAllBedRestRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllBedRestByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllExerciseRecordsByPatientId")]
        public async Task<IActionResult> GetAllExerciseRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllExerciseByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllByMobilityRecordsByPatientId")]
        public async Task<IActionResult> GetAllByMobilityRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllByMobilityRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllWalkAssistanceRecordsByPatientId")]
        public async Task<IActionResult> GetAllWalkAssistanceRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllWalkAssistanceRecordsByPatientIdQuery { PatientId = patientId }));
        }

        //Nutrition

        [HttpGet("GetAllFullWardDietByPatientId")]
        public async Task<IActionResult> GetAllFullWardDietByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllFullWardDietByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllNPORecordByPatientId")]
        public async Task<IActionResult> GetAllNPORecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllNPORecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllSpecialRecordsByPatientId")]
        public async Task<IActionResult> GetAllSpecialRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllSpecialRecordsByPatientIdQuery { PatientId = patientId }));
        }

        //Observation

        [HttpGet("GetAllBloodGlucoseRecordsByPatientId")]
        public async Task<IActionResult> GetAllBloodGlucoseRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllBloodGlucoseRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllBloodFrequencyRecordsByPatientId")]
        public async Task<IActionResult> GetAllBloodFrequencyRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllBloodFrequencyRecordsByPatientIdQuery() { PatientId = patientId }));
        }

        [HttpGet("GetAllNeuroLogicalRecordsByPatientId")]
        public async Task<IActionResult> GetAllNeuroLogicalRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllNeuroLogicalRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllNeuroVascularPatientId")]
        public async Task<IActionResult> GetAllNeuroVascularPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllNeuroVascularPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllUrineTestsByPatientId")]
        public async Task<IActionResult> GetAllUrineTestsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllUrineTestsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllVitalSignRecordsByPatientId")]
        public async Task<IActionResult> GetAllVitalSignRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllVitalSignRecordsByPatientIdQuery { PatientId = patientId }));
        }

        //Oxygenation

        [HttpGet("GetAllInhalaByPatientId")]
        public async Task<IActionResult> GetAllInhalaByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllInhalaByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllMaskByPatientId")]
        public async Task<IActionResult> GetAllMaskByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllMaskByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllNassalCannulRecordsByPatientId")]
        public async Task<IActionResult> GetAllNassalCannulRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllNassalCannulRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllPolyMaskByPatientId")]
        public async Task<IActionResult> GetAllPolyMaskByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllPolyMaskByPatientIdQuery { PatientId = patientId }));
        }

        //Progress Report

        [HttpGet("GetAllProgressReportsByPatientId")]
        public async Task<IActionResult> GetAllProgressReportsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllProgressReportsByPatientIdQuery { PatientId = patientId }));
        }

        //Psychological

        [HttpGet("GetAllCommunicationRecordsByPatientId")]
        public async Task<IActionResult> GetAllCommunicationRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllCommunicationRecordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllHealthEducationByPatientId")]
        public async Task<IActionResult> GetAllHealthEducationByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllHealthEducationByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllSupportRecordsByPatientId")]
        public async Task<IActionResult> GetAllSupportRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllSupportRecordsByPatientIdQuery { PatientId = patientId }));
        }

        //Safety

        [HttpGet("GetAllCheckIDBandRecordsByPatientId")]
        public async Task<IActionResult> GetAllCheckIDBandRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllCheckIDBandREcordsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllCotsideRecordsByPatientId")]
        public async Task<IActionResult> GetAllCotsideRecordsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllCotsideRecordsByPatientIdQuery { PatientId = patientId }));
        }

        //Skin Report

        [HttpGet("GetAllSkinReportsByPatientId")]
        public async Task<IActionResult> GetAllSkinReportsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllSkinReportsByPatientIdQuery { PatientId = patientId }));
        }

        //Skin Integrity Report

        [HttpGet("GetAllPressurePartCareTimeByPatientId")]
        public async Task<IActionResult> GetAllPressurePartCareTimeByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllPressurePartCareTimeByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllRednessReportsById")]
        public async Task<IActionResult> GetAllRednessReportsById(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllRednessReportsByIdQuery { PatientId = patientId }));
        }

        //Stool Report

        [HttpGet("GetAllStoolChartsByPatientId")]
        public async Task<IActionResult> GetAllStoolChartsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllStoolChartsByPatientIdQuery { PatientId = patientId }));
        }

                                        /* GetById Records */

        [HttpGet("GetPrescriptionByPatientId")]
        public async Task<IActionResult> GetPrescriptionByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetPrescriptionByPatientIdQuery { PatientId = patientId }));
        }

        //Comfort Sleep

        [HttpGet("GetComfortSleepRecordByPatientId")]
        public async Task<IActionResult> GetComfortSleepRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetComfortSleepReportByPatientIdQuery { PatientId = patientId }));
        }

        //Daily Care

        [HttpGet("GetDailyCareRecordByPatientId")]
        public async Task<IActionResult> GetDailyCareRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetDailyRecordByPatientIdQuery { PatientId = patientId }));
        }

        //Elimination

        [HttpGet("GetCathetherRecordByPatientId")]
        public async Task<IActionResult> GetCathetherRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetCathetherByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetContinentByPatientId")]
        public async Task<IActionResult> GetContinentByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetContinentByPatientIdQuery { PatientId = patientId }));
        }

        //Fluid Balance

        [HttpGet("Get24HourIntakeByPatientId")]
        public async Task<IActionResult> Get24HourIntakeByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new Get24HourIntakeByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetOralInputCheckByPatientId")]
        public async Task<IActionResult> GetOralInputCheckByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetOralInputByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetOralOutputCheckByPatientId")]
        public async Task<IActionResult> GetOralCheckByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetOralOutputByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetIVCheckByPatientId")]
        public async Task<IActionResult> GetIVCheckByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetIVCheckByPatientIdQuery { PatientId = patientId }));
        }

        //Hygiene

        [HttpGet("GetBedBathAssistByPatientId")]
        public async Task<IActionResult> GetBedBathAssistByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetBedBathAssistByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetBedBathPatientId")]
        public async Task<IActionResult> GetBedBathPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetBedBathRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetSelfCareRecordByPatientId")]
        public async Task<IActionResult> GetSelfCareRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetSelfCareRecordByPatientIdQuery { PatientId = patientId }));
        }

        //Intervention

        [HttpGet("GetIsolationRecordByPatientId")]
        public async Task<IActionResult> GetIsolationRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetIsolationRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetMedicationRecordByPatientId")]
        public async Task<IActionResult> GetMedicationRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetMedicationRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetPostOperativeRecordByPatientId")]
        public async Task<IActionResult> GetPostOperativeRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetPostOperativeRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetTractionByPatientId")]
        public async Task<IActionResult> GetTractionByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetTractionByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetWoundCareByPatientId")]
        public async Task<IActionResult> GetWoundCareByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetWoundCareByPatientIdQuery { PatientId = patientId }));
        }

        //Mobility

        [HttpGet("GetAssistInChairRecordByPatientId")]
        public async Task<IActionResult> GetAssistInChairRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAssistInChairRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetBedRestRecordByPatientId")]
        public async Task<IActionResult> GetBedRestRecordByPatientId (int patientId)
        {
            return Ok(await _mediator.Send(new GetBedRestRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetMobilityRecordByPatientId")]
        public async Task<IActionResult> GetMobilityRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetMobilityRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetExerciseRecordByPatientId")]
        public async Task<IActionResult> GetExerciseRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetExerciseRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetWalkAssistanceByPatientId")]
        public async Task<IActionResult> GetWalkAssistanceByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetWalkAssistanceByPatientIdQuery { PatientId = patientId }));
        }

        //Nutrition

        [HttpGet("GetFullWardDietByPatientId")]
        public async Task<IActionResult> GetFullWardDietByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetFullWardDietByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetNPORecordByPatientId")]
        public async Task<IActionResult> GetNPORecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetNPORecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetSpecialRecordPatientId")]
        public async Task<IActionResult> GetSpecialRecordPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetSpecialRecordPatientIdQuery { PatientId = patientId }));
        }

        //Observation

        [HttpGet("GetBloodFrequencyRecordByPatientId")]
        public async Task<IActionResult> GetBloodFrequencyRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetBloodFrequencyRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetBloodGlucoseRecordByPatientId")]
        public async Task<IActionResult> GetBloodGlucoseRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetBloodGlucoseRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetNeuroLogicalRecordByPatientId")]
        public async Task<IActionResult> GetNeuroLogicalRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetNeuroLogicalRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetNeuroVascularRecordByPatientId")]
        public async Task<IActionResult> GetNeuroVascularRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetNeuroVascularRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetUrineTestByPatientId")]
        public async Task<IActionResult> GetUrineTestByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetUrineTestByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetVitalSignRecordByPatientId")]
        public async Task<IActionResult> GetVitalSignRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetVitalSignRecordByPatientIdQuery { PatientId = patientId }));
        }

        //Oxygenation

        [HttpGet("GetInhalaRecordByPatientId")]
        public async Task<IActionResult> GetInhalaRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetInhalaRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetMaskRecordByPatientId")]
        public async Task<IActionResult> GetMaskRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetMaskRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetNassalCannulByPatientId")]
        public async Task<IActionResult> GetNassalCannulByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetNassalCannulByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetPolyMaskRecordByPatientId")]
        public async Task<IActionResult> GetPolyMaskRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetPolyMaskRecordByPatientIdQuery { PatientId = patientId }));
        }

        //Progress Report

        [HttpGet("GetProgressReportByPatientId")]
        public async Task<IActionResult> GetProgressReportByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetProgressReportByPatientIdQuery { PatientId = patientId }));
        }

        //Psychological

        [HttpGet("GetCommunicationRecordByPatientId")]
        public async Task<IActionResult> GetCommunicationRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetCommunicationRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetHealthEducationByPatientId")]
        public async Task<IActionResult> GetHealthEducationByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetHealthEducationByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetSupportRecordByPatientId")]
        public async Task<IActionResult> GetSupportRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetSupportRecordByPatientIdQuery { PatientId = patientId }));
        }

        //Safety

        [HttpGet("GetCheckIDBandRecordByPatientId")]
        public async Task<IActionResult> GetCheckIDBandRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetCheckIDBandRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetCotsideByPatientId")]
        public async Task<IActionResult> GetCotsideByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetCotsideByPatientIdQuery { PatientId = patientId }));
        }

        //Skin Report

        [HttpGet("GetSkinReportByPatientId")]
        public async Task<IActionResult> GetSkinReportByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetSkinReportByPatientIdQuery { PatientId = patientId }));
        }

        //Skin Integrity Report 

        [HttpGet("GetPressurePartTimeRecordByPatientId")]
        public async Task<IActionResult> GetPressurePartTimeRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetPressurePartTimeRecordByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetRednessRecordByPatientId")]
        public async Task<IActionResult> GetRednessRecordByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetRednessRecordByPatientIdQuery { PatientId = patientId }));
        }

        //Stool Chart

        [HttpGet("GetStoolChartByPatientId")]
        public async Task<IActionResult> GetStoolChartByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetStoolChartByPatientIdQuery { PatientId = patientId }));
        }
    }
}
