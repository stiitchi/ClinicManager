using ClinicManager.Application.Modules.Notification.Commands;
using ClinicManager.Application.Modules.Notification.Queries;
using ClinicManager.Shared.DTO_s.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseApiController<NotificationController>
    {
        [HttpPost]
        public async Task<IActionResult> Add(NotificationDTO notification)
        {
            return Ok(await _mediator.Send(new AddNotificationCommand
            {
                Id                  = notification.Id,
                NotificationType    = notification.NotificationType,
                Description         = notification.Description,
                CreatedOn           = notification.CreatedOn,
                SeenOn              = notification.SeenOn,
                UserId              = notification.UserId
            }));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteNotificationCommand { Id = id }));
        }


        [HttpGet("GetAllNotficationsTable")]
        public async Task<IActionResult> GetAllNotficationsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var rooms = await _mediator.Send(new GetAllNotficationsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(rooms);
        }

        [HttpGet("GetAllNotificationsByTypeTable")]
        public async Task<IActionResult> GetAllNotificationsByTypeTable(int pageNumber, int pageSize, string? searchString, string type, string? orderBy = null)
        {
            var rooms = await _mediator.Send(new GetAllNotificationsByTypeTableQuery(pageNumber, pageSize, searchString, type, orderBy));
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetNotificationByIdQuery { Id = id }));
        }
    }
}
