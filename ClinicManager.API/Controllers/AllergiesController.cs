using ClinicManager.Application.Modules.PatientAllergies.Commands;
using ClinicManager.Application.Modules.PatientAllergies.Queries;
using ClinicManager.Shared.DTO_s.Patients;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : BaseApiController<AllergiesController>
    {

        [HttpGet("GetAllAllergiesByPatientId")]
        public async Task<IActionResult> GetAllAllergiesByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllAllergiesByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllAllergiesByPatientIdTable")]
        public async Task<IActionResult> GetAllAllergiesByPatientIdTable(int pageNumber, int pageSize, string? searchString, int patientId, string? orderBy = null)
        {
            var wards = await _mediator.Send(new GetAllAllergiesByPatientIdTableQuery(pageNumber, pageSize, searchString, patientId, orderBy));
            return Ok(wards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetAlleryByIdQuery { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(AllergyDTO allergy)
        {
            return Ok(await _mediator.Send(new EditPatientCommand
            {
                AllergyId = allergy.AllergyId,
                Description = allergy.Description,
                PatientId = allergy.PatientId
            }));
        }

        [HttpPost("AddVisit")]
        public async Task<IActionResult> AddVisit(AllergyDTO allergy)
        {
            return Ok(await _mediator.Send(new AddPatientAllergyCommand
            {
                AllergyId   = allergy.AllergyId,
                Description = allergy.Description,
                PatientId   = allergy.PatientId
            }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePatientAllergyCommand { Id = id }));
        }
    }
}
