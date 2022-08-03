using ClinicManager.Application.Modules.Faults.Commands;
using ClinicManager.Application.Modules.Faults.Queries;
using ClinicManager.Shared.DTO_s.Faults;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultController : BaseApiController<FaultController>
    {
        [HttpPost]
        public async Task<IActionResult> Add(FaultsDTO fault)
        {
            return Ok(await _mediator.Send(new AddFaultCommand
            {
                Id              = fault.Id,
                FaultTypes      = fault.FaultTypes,
                Severity        = fault.Severity,
                Description     = fault.Description,
                CreatedOn       = fault.CreatedOn,
                SeenOn          = fault.SeenOn,
                UserId          = fault.UserId
            }));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteFaultCommand { Id = id }));
        }


        [HttpGet("GetAllFaultsTable")]
        public async Task<IActionResult> GetAllFaultsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var rooms = await _mediator.Send(new GetAllFaultsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(rooms);
        }

        [HttpGet("GetAllFaultsBySeverityTable")]
        public async Task<IActionResult> GetAllFaultsBySeverityTable(int pageNumber, int pageSize, string? searchString, string severity, string? orderBy = null)
        {
            var rooms = await _mediator.Send(new GetAllFaultsBySeverityTableQuery(pageNumber, pageSize, searchString, severity, orderBy));
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetFaultByIdQuery { Id = id }));
        }
    }
}
