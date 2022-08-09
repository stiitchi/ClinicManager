using ClinicManager.Application.Modules.Subscription.Commands;
using ClinicManager.Application.Modules.Subscription.Queries;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class SubscriptionController : BaseApiController<SubscriptionController>
    {
        [HttpGet("GetAllSubscriptions")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllSubscriptionsQuery { }));
        }

        [HttpGet("GetAllSubscriptionsTable")]
        public async Task<IActionResult> GetAllSubscriptionsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var wards = await _mediator.Send(new GetAllSubscriptionsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(wards);
        }

        [HttpGet("GetAllCheckedSubscriptionsTable")]
        public async Task<IActionResult> GetAllCheckedSubscriptionsTable(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            var wards = await _mediator.Send(new GetAllCheckedSubscriptionsTableQuery(pageNumber, pageSize, searchString, orderBy));
            return Ok(wards);
        }

        [HttpGet("GetSubscriptionByChecked")]
        public async Task<IActionResult> GetSubscriptionByChecked()
        {
            return Ok(await _mediator.Send(new GetSubscriptionByCheckedQuery {}));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetSubscriptionByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteSubscriptionCommand { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Add(SubscriptionDTO subscription)
        {
            return Ok(await _mediator.Send(new AddSubscriptionCommand
            {
                ReferenceNumber = "",
                SubscriptionId  = subscription.Id,
                Email           = subscription.Email,
                MobileNo        = subscription.MobileNo,
                ClinicName      = subscription.ClinicName,
                repFirstName    = subscription.repFirstName,
                repLastName     = subscription.repLastName,
                ClinicAddress   = subscription.ClinicAddress,
                PostalCode      = subscription.PostalCode,
                City            = subscription.City,
                Province        = subscription.Province,
                AmountOfNurses  = subscription.AmountOfNurses,
                StoragePlan     = subscription.StoragePlan,
                PricePerNurse   = subscription.PricePerNurse,
                Amount          = subscription.Amount
            }));
        }
    }
}
