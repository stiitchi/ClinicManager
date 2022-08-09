using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Application.Modules.Azure.Commands;
using ClinicManager.Shared.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureBlobStorageController : BaseApiController<AzureBlobStorageController>
    {
        private readonly IConfiguration _config;
        private readonly IBlobFactory _blobFactory;

        public AzureBlobStorageController(IConfiguration config, IBlobFactory blobFactory)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _blobFactory = blobFactory ?? throw new ArgumentNullException(nameof(blobFactory));
        }

        [HttpPost("AddPDFToBlobStorage")]
        public async Task<IActionResult> AddPDFToBlobStorage(SubscriptionDTO subscription)
        {
            try
            {
                SubscriptionDTO subscriptionDTO = new SubscriptionDTO()
                {
                    Id              = subscription.Id,
                    repFirstName    = subscription.repFirstName,
                    repLastName     = subscription.repLastName,
                    City            = subscription.City,
                    StoragePlan     = subscription.StoragePlan,
                    ReferenceNo     = subscription.ReferenceNo,
                    Province        = subscription.Province,
                    PricePerNurse   = subscription.PricePerNurse,
                    Amount          = subscription.Amount,
                    AmountOfNurses  = subscription.AmountOfNurses,
                    ClinicAddress   = subscription.ClinicAddress,
                    ClinicName      = subscription.ClinicName,
                    MobileNo        = subscription.MobileNo,
                    PostalCode      = subscription.PostalCode,
                    Email           = subscription.Email
                };
                return Ok(await _mediator.Send(new AddPDFToBlobStorageCommand(subscriptionDTO)));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("DownloadPDF")]
        public async Task<IActionResult> DownloadPDF(string referenceNo)
        {
            try
            {
                var connectionString = _config["Azure:ConnectionString"];
                var blobDTO = new DownloadPdfDTO()
                {
                    ReferenceNo = referenceNo
                };
                DownloadPDFCommand downloadPDF = new DownloadPDFCommand()
                {
                    _dto = blobDTO
                };
                var response = await _mediator.Send(downloadPDF);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest($"Error downloading PDF. {e.Message}");
            }
        }
    }
}
