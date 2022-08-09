using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Helpers;
using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.Extensions.Configuration;
using QuestPDF.Fluent;

namespace ClinicManager.Application.Modules.Azure.Commands
{
    public class AddPDFToBlobStorageCommand : IRequest<IResult>
    {
        public SubscriptionDTO _subscription { get; set; }

        public AddPDFToBlobStorageCommand(SubscriptionDTO dto)
        {
            _subscription = dto;
        }
    }

    public class AddPDFToBlobStorageCommandHandler : IRequestHandler<AddPDFToBlobStorageCommand, IResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IBlobFactory _blobFactory;
        private readonly IConfiguration _config;
        private readonly ISendGridService _mailService;

        public AddPDFToBlobStorageCommandHandler(IApplicationDbContext context, IBlobFactory blobFactory, IConfiguration config, ISendGridService mail)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _blobFactory = blobFactory ?? throw new ArgumentNullException(nameof(blobFactory));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _mailService = mail ?? throw new ArgumentNullException(nameof(mail));
        }

        public async Task<IResult> Handle(AddPDFToBlobStorageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var connectionString = _config["Azure:ConnectionString"];

                var blobContainer = await _blobFactory.CreateContainerAsync("pdfs", connectionString, cancellationToken);

                //Images logo and footer
                //var logo_url = "https://cartime.blob.core.windows.net/site-images/car-time-logo.png";
                //var footer_url = "https://cartime.blob.core.windows.net/site-images/pdf-footer-logo.png";
                //HttpClient httpClient = new HttpClient();
                //var logo_response = httpClient.GetAsync(logo_url).Result;
                //byte[] logo_bytes = await logo_response.Content.ReadAsByteArrayAsync();
                //var footer_response = httpClient.GetAsync(footer_url).Result;
                //byte[] footer_bytes = await footer_response.Content?.ReadAsByteArrayAsync();


                //List<byte[]> inspectionData = new List<byte[]>();
                //Images pre-inspection
                //foreach (var inspection in inspectionItems)
                //{
                //    var img_response = httpClient.GetAsync(inspection.Path).Result;
                //    byte[] img_bytes = await img_response.Content.ReadAsByteArrayAsync();
                //    inspectionData.Add(img_bytes);
                //}
                var filePath = $"request-invoice_{request._subscription.ReferenceNo}.pdf";   

                var document = new PDFHelper(request._subscription);


                using (var stream = new MemoryStream())
                {
                    document.GeneratePdf(stream);
                    stream.Position = 0;
                    await blobContainer.DeleteBlobIfExistsAsync(filePath, cancellationToken: cancellationToken);

                    if (request._subscription.Id is 0)
                    {
                        await blobContainer.UploadBlobAsync(filePath, stream, cancellationToken);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
                return await Result.SuccessAsync();
            }
            catch (Exception ex)
            {
                return await Result.FailAsync(ex.Message);
            }
        }
    }
}
