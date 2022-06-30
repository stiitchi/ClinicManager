using ClinicManager.Application.Modules.Patient.Commands;
using ClinicManager.Application.Modules.Patient.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseApiController<PatientController>
    {
        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllPatientsQuery { }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePatientCommand { Id = id }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetPatientByIdQuery { Id = id }));
        }

        [HttpGet("GetPatientByIDNumber")]
        public async Task<IActionResult> GetPatientByIDNumber(long patientId)
        {
            return Ok(await _mediator.Send(new GetPatientByIDNumberQuery { PatientIDNumber = patientId }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetAllPatientsForLookupQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PatientDTO patient)
        {
            return Ok(await _mediator.Send(new AddPatientCommand
            {
                PatientId = patient.Id,
                AccountNo = patient.AccountNo,
                AdmissionDate = patient.AdmissionDate.Value,
                BedNo = patient.BedNo,
                DateOfBirth = patient.DateOfBirth.Value,
                DependentCode = patient.DependentCode,
                Dietician = patient.Dietician,
                DischargeDate = patient.DischargeDate.Value,
                EmergencyContactFirstName = patient.EmergencyContactFirstName,
                EmergencyContactIdNo = patient.EmergencyContactIdNo,
                EmergencyContactLastName = patient.EmergencyContactLastName,
                EmergencyContactNo = patient.EmergencyContactNo,
                FirstName = patient.FirstName,
                Gender = patient.Gender,
                IDNo = patient.IDNo,
                LastName = patient.LastName,    
                Language = patient.Language,
                Location = patient.Location,
                MedicalAidName = patient.MedicalAidName,
                MedicalAidNo = patient.MedicalAidNo,
                MedicalAidOption = patient.MedicalAidOption,
                RefferingDoctor = patient.RefferingDoctor,  
                RefferingHospital = patient.RefferingHospital,
                Relationship = patient.Relationship,
                ReportDate = patient.ReportDate.Value,
                SocialWorker = patient.SocialWorker,
                Title = patient.Title,
                Speech = patient.Speech,
                WardNo = patient.WardNo,
                OT = patient.OT,
                Physio = patient.Physio,
                Psych = patient.Psych,
                Race = patient.Race,
                Stage = patient.Stage
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(PatientDTO patient)
        {
            return Ok(await _mediator.Send(new EditPatientCommand
            {
                PatientId = patient.Id,
                AccountNo = patient.AccountNo,
                AdmissionDate = patient.AdmissionDate.Value,
                BedNo = patient.BedNo,
                DateOfBirth = patient.DateOfBirth.Value,
                DependentCode = patient.DependentCode,
                Dietician = patient.Dietician,
                DischargeDate = patient.DischargeDate.Value,
                EmergencyContactFirstName = patient.EmergencyContactFirstName,
                EmergencyContactIdNo = patient.EmergencyContactIdNo,
                EmergencyContactLastName = patient.EmergencyContactLastName,
                EmergencyContactNo = patient.EmergencyContactNo,
                FirstName = patient.FirstName,
                Gender = patient.Gender,
                IDNo = patient.IDNo,
                LastName = patient.LastName,
                Language = patient.Language,
                Location = patient.Location,
                MedicalAidName = patient.MedicalAidName,
                MedicalAidNo = patient.MedicalAidNo,
                MedicalAidOption = patient.MedicalAidOption,
                RefferingDoctor = patient.RefferingDoctor,
                RefferingHospital = patient.RefferingHospital,
                Relationship = patient.Relationship,
                ReportDate = patient.ReportDate.Value,
                SocialWorker = patient.SocialWorker,
                Title = patient.Title,
                Speech = patient.Speech,
                WardNo = patient.WardNo,
                OT = patient.OT,
                Physio = patient.Physio,
                Psych = patient.Psych,
                Race = patient.Race,
                Stage = patient.Stage
            }));
        }
    }
}
