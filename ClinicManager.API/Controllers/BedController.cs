using ClinicManager.Application.Modules.Bed.Commands;
using ClinicManager.Application.Modules.Bed.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedController : BaseApiController<BedController>
    {

        [HttpGet("GetAllBeds")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllBedsQuery { }));
        }

        [HttpGet("GetAllBedsTable")]
        public async Task<IActionResult> GetAllBedsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var beds = await _mediator.Send(new GetAllBedsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(beds);
        }

        [HttpGet("GetAllBedsByWardIdTable")]
        public async Task<IActionResult> GetAllBedsByWardIdTable(int pageNumber, int pageSize, string? searchString, int wardId, string? orderBy = null)
        {
            var beds = await _mediator.Send(new GetAllBedsByWardIdTableQuery(pageNumber, pageSize, searchString, wardId, orderBy));
            return Ok(beds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetBedByIdQuery { Id = id }));
        }

        [HttpGet("GetAllBedsByWardId")]
        public async Task<IActionResult> GetAllBedsByWardId(int wardId)
        {
            return Ok(await _mediator.Send(new GetAllBedsByWardIdQuery { WardId = wardId }));
        }

        [HttpGet("GetAllOccupiedBedsByWardId")]
        public async Task<IActionResult> GetAllOccupiedBedsByWardId(int wardId)
        {
            return Ok(await _mediator.Send(new GetAllOccupiedBedsByWardIdQuery { WardId = wardId }));
        }

        [HttpGet("GetAllUnoccupiedBedsByWardId")]
        public async Task<IActionResult> GetAllUnoccupiedBedsByWardId(int wardId)
        {
            return Ok(await _mediator.Send(new GetAllUnoccupiedBedsByWardIdQuery { WardId = wardId }));
        }

        [HttpGet("BedsByWardIdLookup")]
        public async Task<IActionResult> BedsByWardIdLookup(int wardId)
        {
            return Ok(await _mediator.Send(new GetBedsByWardIdForLookupQuery { WardId = wardId }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetAllBedsForLookupQuery()));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id, int wardId)
        {
            return Ok(await _mediator.Send(new DeleteBedCommand { Id = id, WardId = wardId }));
        }


        [HttpPost("AssignPatientToBed")]
        public async Task<IActionResult> AssignPatientToBed(int patientId, int bedId)
        {
            return Ok(await _mediator.Send(new AssignBedToPatientCommand
            {
                BedId = bedId,
                PatientId = patientId
            }));
        }


        [HttpPost]
        public async Task<IActionResult> Add(BedDTO bed)
        {
            return Ok(await _mediator.Send(new AddBedCommand
            {
                BedId = bed.BedId,
                WardId = bed.WardId,
                BedNumber = bed.BedNumber,
                WardNumber = bed.WardNumber
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(BedDTO bed)
        {
            return Ok(await _mediator.Send(new EditBedCommand
            {
                BedId = bed.BedId,
                BedNumber = bed.BedNumber,
                WardNumber = bed.WardNumber,
                WardId = bed.WardId
            }));
        }
    }
}

