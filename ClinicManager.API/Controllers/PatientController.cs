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

        [HttpGet("GetAllPatientsTable")]
        public async Task<IActionResult> GetAllPatientsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var patients = await _mediator.Send(new GetAllPatientsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(patients);
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
                WardNo = patient.WardNo,
                BedNo = patient.BedNo,
                CaseInformationNumber = patient.CaseInformationNumber,
                AccountNo = patient.AccountNo,
                AdmissionDate = patient.AdmissionDate,
                DateOfBirth = patient.DateOfBirth,
                DischargeDate = patient.DischargeDate,
                ReportDate = patient.ReportDate,
                Title = patient.Title,
                Initials = patient.Initials,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                IDNo = patient.IDNo,
                PatientTelNo = patient.PatientTelNo,
                PatientCellNo = patient.PatientCellNo,
                PatientWorkTelNo = patient.PatientWorkTelNo,
                Email = patient.Email,
                StreetAddress = patient.StreetAddress,
                City = patient.City,
                Suburb = patient.Suburb,
                Province = patient.Province,
                PostalCode = patient.PostalCode,
                PoBox = patient.PoBox,
                PoBoxCode = patient.PoBoxCode,
                Occupation = patient.Occupation,
                Language = patient.Language,
                Gender = patient.Gender,
                Race = patient.Race,
                EmployerName = patient.EmployerName,
                WorkAddress = patient.WorkAddress,
                WorkAddressCity = patient.WorkAddressCity,
                WorkAddressProvince = patient.WorkAddressProvince,
                WorkAddressCode = patient.WorkAddressCode,
                NextOfKin = patient.NextOfKin,
                NextOfKinContactNo = patient.NextOfKinContactNo,
                RelationshipOfKin = patient.RelationshipOfKin,
                NextOfKinAltContactNo = patient.NextOfKinAltContactNo,
                OtherContact = patient.OtherContact,
                OtherContactNo = patient.OtherContactNo,
                OtherContactRelationship = patient.OtherContactRelationship,
                OtherContactAltContactNo = patient.OtherContactAltContactNo,
                RefferingDoctor = patient.RefferingDoctor,
                RefferingHospital = patient.RefferingHospital,
                MedicalAidName = patient.MedicalAidName,
                MedicalAidNo = patient.MedicalAidNo,
                MedicalAidOption = patient.MedicalAidOption,
                AuthNo = patient.AuthNo,
                DependentCode = patient.DependentCode,
                WoundLocation = patient.WoundLocation,
                Stage = patient.Stage,
                OT = patient.OT,
                Speech = patient.Speech,
                Psych = patient.Psych,
                Dietician = patient.Dietician,
                SocialWorker = patient.SocialWorker,
                Physio = patient.Physio,
                MainMedicalAidMemberFirstName = patient.MainMedicalAidMemberFirstName,
                MainMedicalAidMemberLastName = patient.MainMedicalAidMemberLastName,
                MainMedicalAidMemberIdNumber = patient.MainMedicalAidMemberIdNumber,
                MainMedicalAidMemberRelationship = patient.MainMedicalAidMemberRelationship,
                MainMedicalAidMemberTelNo = patient.MainMedicalAidMemberTelNo,
                MainMedicalAidMemberCellNo = patient.MainMedicalAidMemberCellNo,
                MainMedicalAidMemberStreetAddress = patient.MainMedicalAidMemberStreetAddress,
                MainMedicalAidMemberCity = patient.MainMedicalAidMemberCity,
                MainMedicalAidMemberSuburb = patient.MainMedicalAidMemberSuburb,
                MainMedicalAidMemberProvince = patient.MainMedicalAidMemberProvince,
                MainMedicalAidMemberPostalAddress = patient.MainMedicalAidMemberPostalAddress,
                MainMedicalAidMemberPostalAddressCode = patient.MainMedicalAidMemberPostalAddressCode,
                MainMedicalAidMemberOccupation = patient.MainMedicalAidMemberOccupation,
                MainMedicalAidMemberEmployer = patient.MainMedicalAidMemberEmployer,
                MainMedicalAidMemberBusinessStreetAddress = patient.MainMedicalAidMemberStreetAddress,
                MainMedicalAidMemberBusinessCity = patient.MainMedicalAidMemberBusinessCity,
                MainMedicalAidMemberBusinessProvince = patient.MainMedicalAidMemberBusinessProvince,
                MainMedicalAidBusinessPostalCode = patient.MainMedicalAidMemberBusinessPostalCode
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(PatientDTO patient)
        {
            return Ok(await _mediator.Send(new EditPatientCommand
            {
                PatientId = patient.Id,
                WardNo = patient.WardNo,
                BedNo = patient.BedNo,
                CaseInformationNumber = patient.CaseInformationNumber,
                AccountNo = patient.AccountNo,
                AdmissionDate = patient.AdmissionDate,
                DateOfBirth = patient.DateOfBirth,
                DischargeDate = patient.DischargeDate,
                ReportDate = patient.ReportDate,
                Title = patient.Title,
                Initials = patient.Initials,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                IDNo = patient.IDNo,
                Relationship = patient.RelationshipOfKin,
                PatientTelNo = patient.PatientTelNo,
                PatientCellNo = patient.PatientCellNo,
                PatientWorkTelNo = patient.PatientWorkTelNo,
                Email = patient.Email,
                StreetAddress = patient.StreetAddress,
                City = patient.City,
                Suburb = patient.Suburb,
                Province = patient.Province,
                PostalCode = patient.PostalCode,
                PoBox = patient.PoBox,
                PoBoxCode = patient.PoBoxCode,
                Occupation = patient.Occupation,
                Language = patient.Language,
                Gender = patient.Gender,
                Race = patient.Race,
                EmployerName = patient.EmployerName,
                WorkAddress = patient.WorkAddress,
                WorkAddressCity = patient.WorkAddressCity,
                WorkAddressProvince = patient.WorkAddressProvince,
                WorkAddressCode = patient.WorkAddressCode,
                NextOfKin = patient.NextOfKin,
                NextOfKinContactNo = patient.NextOfKinContactNo,
                RelationshipOfKin = patient.RelationshipOfKin,
                NextOfKinAltContactNo = patient.NextOfKinAltContactNo,
                OtherContact = patient.OtherContact,
                OtherContactNo = patient.OtherContactNo,
                OtherContactRelationship = patient.OtherContactRelationship,
                OtherContactAltContactNo = patient.OtherContactAltContactNo,
                RefferingDoctor = patient.RefferingDoctor,
                RefferingHospital = patient.RefferingHospital,
                MedicalAidName = patient.MedicalAidName,
                MedicalAidNo = patient.MedicalAidNo,
                MedicalAidOption = patient.MedicalAidOption,
                AuthNo = patient.AuthNo,
                DependentCode = patient.DependentCode,
                WoundLocation = patient.WoundLocation,
                Stage = patient.Stage,
                OT = patient.OT,
                Speech = patient.Speech,
                Psych = patient.Psych,
                Dietician = patient.Dietician,
                SocialWorker = patient.SocialWorker,
                Physio = patient.Physio,
                MainMedicalAidMemberFirstName = patient.MainMedicalAidMemberFirstName,
                MainMedicalAidMemberLastName = patient.MainMedicalAidMemberLastName,
                MainMedicalAidMemberIdNumber = patient.MainMedicalAidMemberIdNumber,
                MainMedicalAidMemberRelationship = patient.MainMedicalAidMemberRelationship,
                MainMedicalAidMemberTelNo = patient.MainMedicalAidMemberTelNo,
                MainMedicalAidMemberCellNo = patient.MainMedicalAidMemberCellNo,
                MainMedicalAidMemberStreetAddress = patient.MainMedicalAidMemberStreetAddress,
                MainMedicalAidMemberCity = patient.MainMedicalAidMemberCity,
                MainMedicalAidMemberSuburb = patient.MainMedicalAidMemberSuburb,
                MainMedicalAidMemberProvince = patient.MainMedicalAidMemberProvince,
                MainMedicalAidMemberPostalAddress = patient.MainMedicalAidMemberPostalAddress,
                MainMedicalAidMemberPostalAddressCode = patient.MainMedicalAidMemberPostalAddressCode,
                MainMedicalAidMemberOccupation = patient.MainMedicalAidMemberOccupation,
                MainMedicalAidMemberEmployer = patient.MainMedicalAidMemberEmployer,
                MainMedicalAidMemberBusinessStreetAddress = patient.MainMedicalAidMemberStreetAddress,
                MainMedicalAidMemberBusinessCity = patient.MainMedicalAidMemberBusinessCity,
                MainMedicalAidMemberBusinessProvince = patient.MainMedicalAidMemberBusinessProvince,
                MainMedicalAidBusinessPostalCode = patient.MainMedicalAidMemberBusinessPostalCode      
            }));
        }
    }
}
