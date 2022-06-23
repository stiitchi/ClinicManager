using ClinicManager.Application.Modules.ICDCode.Commands;
using ClinicManager.Application.Modules.ICDCode.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDCodeController : BaseApiController<ICDCodeController>
    {

        [HttpGet("GetAllICDCodes")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllICDCodesQuery { }));
        }

        [HttpGet("GetAllPatientICDCodes")]
        public async Task<IActionResult> GetAllPatientICDCodes(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllPatientICDCodesQuery { PatientId = patientId }));
        }

        [HttpGet("GetAllICDCodesTable")]
        public async Task<IActionResult> GetAllICDCodesTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var wards = await _mediator.Send(new GetAllICDCodesTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(wards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetICDCodeByIdQuery { Id = id }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetAllICDCodesForLookupQuery()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteICDCodeCommand { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ICDCodeDTO icd)
        {
            return Ok(await _mediator.Send(new AddICDCodeCommand
            {
                DateAdded = icd.DateAdded,
                Description = icd.Description,
                ICDCode = icd.ICDCode
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ICDCodeDTO icd)
        {
            return Ok(await _mediator.Send(new EditICDCodeCommand
            {
                Id = icd.ICDCodeId,
                DateAdded = icd.DateAdded,
                Description = icd.Description,
                ICDCode = icd.ICDCode
            }));
        }

        [HttpPost("AddPatientICDCode")]
        public async Task<IActionResult> AddPatientICDCode(PatientICDCodeDTO patientDayfee)
        {
            return Ok(await _mediator.Send(new AssignICDCodeToPatientCommand
            {
                PatientICDCodeId = patientDayfee.PatientICDCodeId,
                ICDCodeId = patientDayfee.ICDCodeId,
                PatientId = patientDayfee.PatientId
            }));
        }
    }
}
