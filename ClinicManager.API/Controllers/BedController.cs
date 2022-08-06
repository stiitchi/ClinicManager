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

        [HttpGet("GetAllBedsByRoomId")]
        public async Task<IActionResult> GetAllBedsByRoomId(int roomId)
        {
            return Ok(await _mediator.Send(new GetAllBedsByRoomIdQuery { RoomId = roomId }));
        }

        [HttpGet("GetAllOccupiedBeds")]
        public async Task<IActionResult> GetAllOccupiedBeds(int roomId)
        {
            return Ok(await _mediator.Send(new GetAllOccupiedBedsByRoomIdQuery {  RoomId = roomId }));
        }


        [HttpGet("GetAllUnOccupiedBeds")]
        public async Task<IActionResult> GetAllUnOccupiedBeds(int roomId)
        {
            return Ok(await _mediator.Send(new GetAllUnoccupiedBedsByRoomIdQuery { RoomId = roomId }));

        }

        [HttpGet("GetAllBedsTable")]
        public async Task<IActionResult> GetAllBedsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var beds = await _mediator.Send(new GetAllBedsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(beds);
        }

        [HttpGet("GetAllBedsByRoomIdTable")]
        public async Task<IActionResult> GetAllBedsByRoomIdTable(int pageNumber, int pageSize, string? searchString, int roomId, string? orderBy = null)
        {
            var beds = await _mediator.Send(new GetAllBedsByRoomIdTableQuery(pageNumber, pageSize, searchString, roomId, orderBy));
            return Ok(beds);
        }

        [HttpGet("GetAllOccupiedBedsTable")]
        public async Task<IActionResult> GetAllOccupiedBedsTable(int pageNumber, int pageSize, string? searchString, int roomId, string? orderBy = null)
        {
            var beds = await _mediator.Send(new GetAllOccupiedBedsTableQuery(pageNumber, pageSize, searchString, roomId, orderBy));
            return Ok(beds);
        }

        [HttpGet("GetAllUnOccupiedBedsTable")]
        public async Task<IActionResult> GetAllUnOccupiedBedsTable(int pageNumber, int pageSize, string? searchString, int roomId, string? orderBy = null)
        {
            var beds = await _mediator.Send(new GetAllUnoccupiedBedsTableQuery(pageNumber, pageSize, searchString, roomId, orderBy));
            return Ok(beds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetBedByIdQuery { Id = id }));
        }

        [HttpGet("BedsByRoomIdLookup")]
        public async Task<IActionResult> BedsByRoomIdLookup(string roomNo)
        {
            return Ok(await _mediator.Send(new GetBedsByRoomIdForLookupQuery { RoomNo = roomNo }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetAllBedsForLookupQuery()));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id, int roomId)
        {
            return Ok(await _mediator.Send(new DeleteBedCommand { Id = id, RoomId = roomId }));
        }

        [HttpPost]
        public async Task<IActionResult> Add(BedDTO bed)
        {
            return Ok(await _mediator.Send(new AddBedCommand
            {
                BedId     = bed.BedId,
                RoomId    = bed.RoomId.Value,
                BedNumber = bed.BedNumber
            }));
        }

        [HttpPost("AssignPatientToBed")]
        public async Task<IActionResult> AssignPatientToBed(MovePatientDTO movePatient)
        {
            return Ok(await _mediator.Send(new AssignBedToPatientCommand
            {
                BedId        = movePatient.BedId,
                RoomId       = movePatient.RoomId,
                WardId       = movePatient.WardId,
                PatientBedId = movePatient.PatientBedId,
                PatientId    = movePatient.PatientId
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(BedDTO bed)
        {
            return Ok(await _mediator.Send(new EditBedCommand
            {
                BedId      = bed.BedId,
                RoomNumber = bed.RoomNumber,
                BedNumber  = bed.BedNumber
            }));
        }
    }
}

