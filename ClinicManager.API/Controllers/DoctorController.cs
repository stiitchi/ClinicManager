using ClinicManager.Application.Modules.Doctor.Commands;
using ClinicManager.Application.Modules.Doctor.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseApiController<DoctorController>
    {
        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllDoctorsQuery { }));
        }

        [HttpGet("GetAllDoctorTable")]
        public async Task<IActionResult> GetAllDoctorsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var doctors = await _mediator.Send(new GetAllDoctorsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetDoctorByIdQuery { Id = id }));
        }

        [HttpGet("ForLookup")]
        public async Task<IActionResult> ForLookup()
        {
            return Ok(await _mediator.Send(new GetAllDoctorsForLookupQuery()));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteDoctorCommand { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDTO user)
        {
            return Ok(await _mediator.Send(new AddDoctorCommand
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNo = user.MobileNo
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(UserDTO user)
        {
            return Ok(await _mediator.Send(new EditDoctorCommand
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNo = user.MobileNo
            }));
        }
    }
}

