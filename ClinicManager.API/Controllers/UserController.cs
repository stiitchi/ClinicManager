using ClinicManager.Application.Modules.User.Commands;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController<UsersController>
    {

        //[HttpGet]
        //public async Task<IActionResult> GetAll(int pageNumber, int pageSize, string searchString, string orderBy = null)
        //{
        //    var users = await _mediator.Send(new GetAllUsersQuery(pageNumber, pageSize, searchString, orderBy));
        //    return Ok(users);
        //}

        //[HttpGet("ForLookup")]
        //public async Task<IActionResult> ForLookup()
        //{
        //    return Ok(await _mediator.Send(new GetAllUsersForLookupQuery()));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await _mediator.Send(new GetUserByIdQuery { Id = id }));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await _mediator.Send(new DeleteUserCommand { Id = id }));
        //}

        //[HttpPut]
        //public async Task<IActionResult> Edit(UserDTO user)
        //{
        //    return Ok(await _mediator.Send(new EditUserCommand
        //    {
        //        Id = user.Id,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Email = user.Email,
        //        MobileNo = user.MobileNo
        //    }));
        //}

        [HttpPost]
        public async Task<IActionResult> Add(UserDTO user)
        {
            return Ok(await _mediator.Send(new AddUserCommand
            {
                UserId = user.Id,
                Name = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                MobileNo = user.MobileNo
            }));
        }
    }
}
}
