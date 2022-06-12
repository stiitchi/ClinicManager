using ClinicManager.Application.Modules.DayFees.Commands;
using ClinicManager.Application.Modules.DayFees.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayFeeController : BaseApiController<DayFeeController>
    {
        [HttpGet("GetAllDayFees")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllDayFeesQuery { }));
        }

        [HttpGet("GetAllDayFeesTable")]
        public async Task<IActionResult> GetAllDayFeesTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var wards = await _mediator.Send(new GetAllDayFeesTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(wards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetDayFeeByIdQuery { Id = id }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetAllDayFeesForLookupQuery()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteDayFeeCommand { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Add(DayFeesDTO dayFees)
        {
            return Ok(await _mediator.Send(new AddDayFeeCommand
            {
                DateAdded = dayFees.DateAdded,
                Description = dayFees.Description,
                DayFeeCode = dayFees.DayFeeCode
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(DayFeesDTO dayFees)
        {
            return Ok(await _mediator.Send(new EditDayFeeCommand
            {
                Id = dayFees.DayFeeID,
                DateAdded = dayFees.DateAdded,
                Description = dayFees.Description,
                DayFeeCode = dayFees.DayFeeCode
            }));
        }
    }
}
