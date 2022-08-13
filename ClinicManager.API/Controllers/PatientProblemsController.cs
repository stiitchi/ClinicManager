using ClinicManager.Application.Modules.PatientProblems.Commands;
using ClinicManager.Application.Modules.PatientProblems.Queries;
using ClinicManager.Shared.DTO_s.Patients;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientProblemsController : BaseApiController<PatientProblemsController>
    {

        [HttpGet("GetAllPatientProblemsByPatientId")]
        public async Task<IActionResult> GetAllPatientProblemsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllPatientProblemsByPatientIdQuery { PatientId = patientId }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetPatientProblemByIdQuery { Id = id }));
        }

        [HttpGet("GetAllPatientProblemsByPatientIdTable")]
        public async Task<IActionResult> GetAllPatientProblemsByPatientIdTable(int pageNumber, int pageSize, string? searchString, int patientId, string? orderBy = null)
        {
            var wards = await _mediator.Send(new GetAllPatientProblemsByPatientIdTableQuery(pageNumber, pageSize, searchString, patientId, orderBy));
            return Ok(wards);
        }

        [HttpPost("AddPatientProblem")]
        public async Task<IActionResult> AddPatientProblem(ProblemsDTO problems)
        {
            return Ok(await _mediator.Send(new AddPatientProblemCommand
            {
                ProblemId   = problems.ProblemId,
                Description = problems.Description,
                OnSetDate   = problems.OnSetDate,
                PatientId   = problems.PatientId
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ProblemsDTO problems)
        {
            return Ok(await _mediator.Send(new EditPatientProblemCommand
            {
                ProblemId   = problems.ProblemId,
                Description = problems.Description,
                OnSetDate   = problems.OnSetDate,
                PatientId   = problems.PatientId
            }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeletePatientProblemCommand { Id = id }));
        }
    }
}
