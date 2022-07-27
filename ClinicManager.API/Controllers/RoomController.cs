using ClinicManager.Application.Modules.Room.Commands;
using ClinicManager.Application.Modules.Room.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : BaseApiController<RoomController>
    {

        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllRoomsQuery { }));
        }

        [HttpGet("GetRoomsByRoomNumber")]
        public async Task<IActionResult> GetWardsByWardNumber(string roomNumber)
        {
            return Ok(await _mediator.Send(new GetRoomsByRoomNumberQuery { RoomNumber = roomNumber }));
        }

        [HttpGet("GetAllRoomsByWardIdTable")]
        public async Task<IActionResult> GetAllRoomsByWardIdTable(int pageNumber, int pageSize, string? searchString, int wardId, string? orderBy = null)
        {
            var rooms = await _mediator.Send(new GetAllRoomsByWardIdTableQuery(pageNumber, pageSize, searchString, wardId, orderBy));
            return Ok(rooms);
        }

        [HttpGet("GetAllRoomsByWardId")]
        public async Task<IActionResult> GetAllRoomsByWardId(int wardId)
        {
            return Ok(await _mediator.Send(new GetRoomsByWardIdQuery { WardId = wardId }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetRoomByIdQuery { Id = id }));
        }


        [HttpGet("RoomsByWardIdLookup")]
        public async Task<IActionResult> RoomsByWardIdLookup(int wardId)
        {
            return Ok(await _mediator.Send(new GetRoomsByWardIdForLookupQuery { WardId = wardId }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetRoomsForLookupQuery()));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id, int wardId)
        {
            return Ok(await _mediator.Send(new DeleteRoomCommand { Id = id , WardId = wardId}));
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoomDTO room)
        {
            return Ok(await _mediator.Send(new AddRoomCommand
            {
                WardId = room.WardId,
                RoomNumber = room.RoomNumber
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(RoomDTO room)
        {
            return Ok(await _mediator.Send(new EditRoomCommand
            {
                WardId = room.WardId,
                RoomNumber = room.RoomNumber
            }));
        }
    }
}
