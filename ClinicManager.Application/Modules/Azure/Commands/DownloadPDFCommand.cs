using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Shared.DTO_s;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ClinicManager.Application.Modules.Azure.Commands
{
    public class DownloadPDFCommand : IRequest<DownloadPdfDTO>
    {
        public DownloadPdfDTO _dto { get; set; }
    }

    public class DownloadPDFCommandHandler : IRequestHandler<DownloadPDFCommand, DownloadPdfDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IBlobFactory _blobFactory;
        private readonly IConfiguration _config;
        public DownloadPDFCommandHandler(IApplicationDbContext context, IBlobFactory blobFactory, IConfiguration config)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _blobFactory = blobFactory ?? throw new ArgumentNullException(nameof(blobFactory));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task<DownloadPdfDTO> Handle(DownloadPDFCommand request, CancellationToken cancellationToken)
        {
            var connectionString = _config["Azure:ConnectionString"];

            var blobDTO = new DownloadPdfDTO();
            var containerName = "pdfs";
            var blobName = $"request-invoice_{request._dto.ReferenceNo}.pdf";

            var blob = await _blobFactory.GetBlob(containerName, blobName, connectionString);

            blobDTO.PDF = blob;
            blobDTO.PDFName = blobName;

            return blobDTO;
        }
    }
}
