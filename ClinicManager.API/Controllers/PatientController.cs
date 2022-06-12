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
                CaseInformationNumber = patient.CaseInformationNumber,
                PatientId = patient.Id,
                AccountNo = patient.AccountNo,
                AdmissionDate = patient.AdmissionDate,
                AdmissionTime = patient.AdmissionTime,
                FullName = patient.FullName,
                LastName = patient.LastName,
                Title = patient.Title,
                Initials = patient.Initials,
                IDNo = patient.IDNo,
                HomeTelNo = patient.HomeTelNo,
                WorkTelNo = patient.WorkTelNo,
                CellNo = patient.CellNo,
                DateOfBirth = patient.DateOfBirth,
                Address = patient.Address,
                POBox = patient.POBox,
                POBoxCode = patient.POBoxCode,
                Occupation = patient.Occupation,
                Language = patient.Language,
                Gender = patient.Gender,
                Race = patient.Race,
                EmployerName = patient.EmployerName,
                WorkAddress = patient.WorkAddress,
                WorkAddressPostalCode = patient.WorkAddressPostalCode,
                NextOfKin = patient.NextOfKin,
                ContactNo = patient.ContactNo,
                RelationshipOfKin = patient.RelationshipOfKin,
                AltContact = patient.AltContact,
                AltContactNo = patient.AltContactNo,
                AltContactRelationship = patient.AltContactRelationship,
                MedicalAidNo = patient.MedicalAidNo,
                MedicalAidName = patient.MedicalAidName,
                MedicalAidOption = patient.MedicalAidOption,
                AuthNo = patient.AuthNo,
                DependentCode = patient.DependentCode,
                MedicalAidMemberName = patient.MedicalAidMemberName,
                MedicalAidMemberSurname = patient.MedicalAidMemberSurname,
                MedicalAidMemberIdNo = patient.MedicalAidMemberIdNo,
                MedicalAidMemberTelNo = patient.MedicalAidMemberTelNo,
                MedicalAidMemberCellNo = patient.MedicalAidMemberCellNo,
                MedicalAidMemberPostalAddress = patient.MedicalAidMemberPostalAddress,
                MedicalAidMemberCode = patient.MedicalAidMemberCode,
                MedicalAidMemberOccupation = patient.MedicalAidMemberOccupation,
                MedicalAidMemberEmployer = patient.MedicalAidMemberEmployer,
                MedicalAidMemberBusinessAddress = patient.MedicalAidMemberBusinessAddress,
                MedicalAidMemberBusinessPostalCode = patient.MedicalAidMemberBusinessPostalCode
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(PatientDTO patient)
        {
            return Ok(await _mediator.Send(new EditPatientCommand
            {
                CaseInformationNumber = patient.CaseInformationNumber,
                PatientId = patient.Id,
                AccountNo = patient.AccountNo,
                AdmissionDate = patient.AdmissionDate,
                AdmissionTime = patient.AdmissionTime,
                FullName = patient.FullName,
                LastName = patient.LastName,
                Title = patient.Title,
                Initials = patient.Initials,
                IDNo = patient.IDNo,
                HomeTelNo = patient.HomeTelNo,
                WorkTelNo = patient.WorkTelNo,
                CellNo = patient.CellNo,
                DateOfBirth = patient.DateOfBirth,
                Address = patient.Address,
                POBox = patient.POBox,
                POBoxCode = patient.POBoxCode,
                Occupation = patient.Occupation,
                Language = patient.Language,
                Gender = patient.Gender,
                Race = patient.Race,
                EmployerName = patient.EmployerName,
                WorkAddress = patient.WorkAddress,
                WorkAddressPostalCode = patient.WorkAddressPostalCode,
                NextOfKin = patient.NextOfKin,
                ContactNo = patient.ContactNo,
                RelationshipOfKin = patient.RelationshipOfKin,
                AltContact = patient.AltContact,
                AltContactNo = patient.AltContactNo,
                AltContactRelationship = patient.AltContactRelationship,
                MedicalAidNo = patient.MedicalAidNo,
                MedicalAidName = patient.MedicalAidName,
                MedicalAidOption = patient.MedicalAidOption,
                AuthNo = patient.AuthNo,
                DependentCode = patient.DependentCode,
                MedicalAidMemberName = patient.MedicalAidMemberName,
                MedicalAidMemberSurname = patient.MedicalAidMemberSurname,
                MedicalAidMemberIdNo = patient.MedicalAidMemberIdNo,
                MedicalAidMemberTelNo = patient.MedicalAidMemberTelNo,
                MedicalAidMemberCellNo = patient.MedicalAidMemberCellNo,
                MedicalAidMemberPostalAddress = patient.MedicalAidMemberPostalAddress,
                MedicalAidMemberCode = patient.MedicalAidMemberCode,
                MedicalAidMemberOccupation = patient.MedicalAidMemberOccupation,
                MedicalAidMemberEmployer = patient.MedicalAidMemberEmployer,
                MedicalAidMemberBusinessAddress = patient.MedicalAidMemberBusinessAddress,
                MedicalAidMemberBusinessPostalCode = patient.MedicalAidMemberBusinessPostalCode
            }));
        }
    }
}
