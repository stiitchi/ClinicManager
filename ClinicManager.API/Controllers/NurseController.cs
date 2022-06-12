using ClinicManager.Application.Modules.Nurses.Commands;
using ClinicManager.Application.Modules.Nurses.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : BaseApiController<NurseController>
    {
        [HttpGet("GetAllBeds")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllNursesQuery { }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetNurseByIdQuery { Id = id }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetAllNursesForLookupQuery()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteNurseCommand { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDTO user)
        {
            return Ok(await _mediator.Send(new AddNurseCommand
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNo = user.MobileNo
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(UserDTO user)
        {
            return Ok(await _mediator.Send(new EditNurseCommand
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNo = user.MobileNo
            }));
        }
    }
}

