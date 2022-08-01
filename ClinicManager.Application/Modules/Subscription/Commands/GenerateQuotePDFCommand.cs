using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Application.Helpers;
using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuestPDF.Fluent;

namespace ClinicManager.Application.Modules.Subscription.Commands
{
    public class GenerateQuotePDFCommand : IRequest<IResult>
    {
        public SubscriptionDTO _subscription { get; set; }
    }

    public class GenerateQuotePDFCommandHandler : IRequestHandler<GenerateQuotePDFCommand, IResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ISendGridService _mailService;

        public GenerateQuotePDFCommandHandler(IApplicationDbContext context, IConfiguration config, ISendGridService mail)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _mailService = mail ?? throw new ArgumentNullException(nameof(mail));
        }

        public async Task<IResult> Handle(GenerateQuotePDFCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var subscription = await _context.Subscriptions.Where(a => a.Id == request._subscription.Id).FirstOrDefaultAsync();
                if (subscription == null)
                {
                    return await Result<bool>.FailAsync("Subscription not found");
                }

                var document = new PDFHelper(subscription);


                using (var stream = new MemoryStream())
                {
                    document.GeneratePdf(stream);
                    stream.Position = 0;
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
