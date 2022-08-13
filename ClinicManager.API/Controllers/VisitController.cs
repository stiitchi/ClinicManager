using ClinicManager.Application.Modules.Visits.Commands;
using ClinicManager.Application.Modules.Visits.Queries;
using ClinicManager.Shared.DTO_s.Patients;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : BaseApiController<VisitController>
    {
        [HttpGet("GetAllVisits")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllVisitsQuery { }));
        }

        [HttpGet("GetAllVisitsByPatientId")]
        public async Task<IActionResult> GetAllVisitsByPatientId(int patientId)
        {
            return Ok(await _mediator.Send(new GetAllVisitsByPatientIdQuery { PatientId = patientId }));
        }


        [HttpGet("GetAllVisitsTable")]
        public async Task<IActionResult> GetAllVisitsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var wards = await _mediator.Send(new GetAllVisitsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(wards);
        }

        [HttpGet("GetAllVisitsByPatientIdTable")]
        public async Task<IActionResult> GetAllVisitsByPatientIdTable(int pageNumber, int pageSize, string? searchString, int patientId, string? orderBy = null)
        {
            var wards = await _mediator.Send(new GetAllVisitsByPatientIdTableQuery(pageNumber, pageSize, searchString, patientId, orderBy));
            return Ok(wards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetVisitByIdQuery { Id = id }));
        }


        [HttpPut]
        public async Task<IActionResult> Edit(VisitDTO visit)
        {
            return Ok(await _mediator.Send(new EditVisitCommand
            {
                VisitId            = visit.VisitId,
                StartDate          = visit.StartDate,
                EndDate            = visit.EndDate,
                ProblemDescription = visit.ProblemDescription,
                Address            = visit.Address,
                City               = visit.City,
                PostalCode         = visit.PostalCode,
                Province           = visit.Province,
                PatientId          = visit.PatientId
            }));
        }

        [HttpPost("AddVisit")]
        public async Task<IActionResult> AddVisit(VisitDTO visit)
        {
            return Ok(await _mediator.Send(new AddVisitCommand
            {
                VisitId            = visit.VisitId,
                StartDate          = visit.StartDate,
                EndDate            = visit.EndDate,
                ProblemDescription = visit.ProblemDescription,
                Address            = visit.Address,
                City               = visit.City,
                PostalCode         = visit.PostalCode,
                Province           = visit.Province,
                PatientId          = visit.PatientId
            }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteVisitCommand { Id = id }));
        }
    }
}
