using ClinicManager.Application.Modules.Ward.Commands;
using ClinicManager.Application.Modules.Ward.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : BaseApiController<WardController>
    {

        [HttpGet("GetAllWards")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllWardsQuery { }));
        }

        [HttpGet("GetAllWardsTable")]
        public async Task<IActionResult> GetAllWardsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var wards = await _mediator.Send(new GetAllWardsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(wards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetWardByIdQuery { Id = id }));
        }

        [HttpGet("GetWardsByWardNumber")]
        public async Task<IActionResult> GetWardsByWardNumber(int wardNumber)
        {
            return Ok(await _mediator.Send(new GetAllWardsByWardNumber { WardNumber = wardNumber }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetAllWardsForLookupQuery()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteWardCommand { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Add(WardDTO ward)
        {
            return Ok(await _mediator.Send(new AddWardCommand
            {
                WardId = ward.WardId,
                RoomNumber = ward.RoomNumber,
                WardNumber = ward.WardNumber,
                TotalBeds = ward.TotalBeds
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(WardDTO ward)
        {
            return Ok(await _mediator.Send(new EditWardCommand
            {
                WardId = ward.WardId,
                RoomNumber = ward.RoomNumber,
                WardNumber = ward.WardNumber,
                TotalBeds = ward.TotalBeds
            }));
        }
    }
}
