using ClinicManager.Application.Modules.Admissions.Commands;
using ClinicManager.Application.Modules.Admissions.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : BaseApiController<AdmissionController>
    {
        [HttpGet("GetAllAdmissions")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllAdmissionsQuery { }));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetAdmissionByIdQuery { Id = id }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetAdmissionsForLookupQuery()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteAdmissionCommand { Id = id }));
        }

        [HttpPost("AddAdmission")]
        public async Task<IActionResult> Add(AdmissionDTO admission)
        {
            return Ok(await _mediator.Send(new AddAdmissionCommand
            {
                AdmissionId = admission.AdmissionId,
                CaseInformationNumber = admission.CaseInformationNumber,
                AccountNo = admission.AccountNo,
                AdmissionDate = admission.AdmissionDate,
                AdmissionTime = admission.AdmissionTime,
                Title = admission.Title,
                Initials = admission.Initials,
                LastName = admission.LastName,
                FullName = admission.PatientFullName,
                IDNo = admission.IDNo,
                DateOfBirth = admission.DateOfBirth,
                HomeTelNo = admission.HomeTelNo,
                CellNo = admission.CellNo,
                WorkTelNo = admission.WorkTelNo,
                Email = admission.Email,
                HomeAddress = admission.HomeAddress,
                HomePostalCode = admission.HomePostalCode,
                POBox = admission.POBox,
                POBoxCode = admission.POBoxCode,
                Occupation = admission.Occupation,
                Language = admission.Language,
                Gender = admission.Gender,
                Race = admission.Race,
                EmployerName = admission.EmployerName,
                WorkAddress = admission.WorkAddress,
                WorkAddressPostalCode = admission.WorkAddressPostalCode,
                NextOfKin = admission.NextOfKin,
                ContactNoKin = admission.ContactNoKin,
                RelationshipOfKin = admission.RelationshipOfKin,
                AltContactNoKin = admission.AltContactNoKin,
                OtherContact = admission.OtherContact,
                OtherContactNo = admission.OtherContactNo,
                OtherContactRelationship = admission.OtherContactRelationship,
                OtherContactNoAlt = admission.OtherContactNoAlt,
                MedicalAidName = admission.MedicalAidName,
                MedicalAidOption = admission.MedicalAidOption,
                MedicalAidNo = admission.MedicalAidNo,
                AuthNo = admission.AuthNo,
                DependentCode = admission.DependentCode,
                MedicalAidMemberFullName = admission.MedicalAidMemberFullName,
                MedicalAidMemberIdNo = admission.MedicalAidMemberIdNo,
                MedicalAidMemberRelationship = admission.MedicalAidMemberRelationship,
                MedicalAidMemberTelNo = admission.MedicalAidMemberTelNo,
                MedicalAidMemberCellNo = admission.MedicalAidMemberCellNo,
                MedicalAidMemberPostalAddress = admission.MedicalAidMemberPostalAddress,
                MedicalAidMemberPostalAddressCode = admission.MedicalAidMemberPostalAddressCode,
                MedicalAidMemberHomeAddress = admission.MedicalAidMemberHomeAddress,
                MedicalAidMemberHomePostalCode = admission.MedicalAidMemberHomePostalCode,
                MedicalAidMemberOccupation = admission.MedicalAidMemberOccupation,
                MedicalAidMemberEmployerName = admission.MedicalAidMemberEmployerName,
                MedicalAidMemberBusinessAddress = admission.MedicalAidMemberBusinessAddress,
                MedicalAidMemberBusinessPostalCode = admission.MedicalAidMemberBusinessPostalCode
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(AdmissionDTO admission)
        {
            return Ok(await _mediator.Send(new EditAdmissionCommand
            {
                //AdmissionId = admission.AdmissionId,
                //CaseInformationNumber = admission.CaseInformationNumber,
                //AccountNo = admission.AccountNo,
                //AdmissionDate = admission.AdmissionDate,
                //AdmissionTime = admission.AdmissionTime,
                //Title = admission.Title,
                //Initials = admission.Initials,
                //LastName = admission.LastName,
                //FullName = admission.PatientFullName,
                //IDNo = admission.IDNo,
                //DateOfBirth = admission.DateOfBirth,
                //HomeTelNo = admission.HomeTelNo,
                //CellNo = admission.CellNo,
                //WorkTelNo = admission.WorkTelNo,
                //Email = admission.Email,
                //HomeAddress = admission.HomeAddress,
                //HomePostalCode = admission.HomePostalCode,
                //POBox = admission.POBox,
                //POBoxCode = admission.POBoxCode,
                //Occupation = admission.Occupation,
                //Language = admission.Language,
                //Gender = admission.Gender,
                //Race = admission.Race,
                //EmployerName = admission.EmployerName,
                //WorkAddress = admission.WorkAddress,
                //WorkAddressPostalCode = admission.WorkAddressPostalCode,
                //NextOfKin = admission.NextOfKin,
                //ContactNo = admission.ContactNo,
                //RelationshipOfKin = admission.RelationshipOfKin,
                //AltContactNo = admission.AltContactNo,
                //RelationshipContact = admission.RelationshipContact,
                //AltContact = admission.AltContact,
                //AltContactNoAlt = admission.AltContactNoAlt,
                //AltContactRelationship = admission.AltContactRelationship,
                //AltOtherContactNo = admission.AltOtherContactNo,
                //MedicalAidName = admission.MedicalAidName,
                //MedicalAidOption = admission.MedicalAidOption,
                //MedicalAidNo = admission.MedicalAidNo,
                //AuthNo = admission.AuthNo,
                //DependentCode = admission.DependentCode,
                //FullNameAcc = admission.FullNameAcc,
                //IDNoAcc = admission.IDNoAcc,
                //RelationshipAcc = admission.RelationshipAcc,
                //PostalAddressAcc = admission.PostalAddressAcc,
                //PostalCodeAcc = admission.PostalCodeAcc,
                //AddressAcc = admission.AddressAcc,
                //OccupationAcc = admission.OccupationAcc,
                //BusinessAddressAcc = admission.BusinessAddressAcc,
                //BusinessPostalCodeAcc = admission.BusinessPostalCodeAcc

            }));
        }
    }
}
