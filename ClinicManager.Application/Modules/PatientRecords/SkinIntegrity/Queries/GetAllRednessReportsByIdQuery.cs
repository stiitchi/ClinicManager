using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity;
using ClinicManager.Shared.DTO_s.Records.SkinIntegrity;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Queries
{
    public class GetAllRednessReportsByIdQuery : IRequest<Result<List<RednessDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllRednessReportsByIdQueryHandler : IRequestHandler<GetAllRednessReportsByIdQuery, Result<List<RednessDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllRednessReportsByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<RednessDTO>>> Handle(GetAllRednessReportsByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<RednessEntity, RednessDTO>> expression = e => new RednessDTO
                {
                    ReportRednessSignature = e.ReportRednessSignature,
                    ReportRednessFrequency = e.ReportRednessFrequency,
                    ReportRednessTime = e.ReportRednessTime,
                    PatientId = e.PatientId
                };

                var rednessEntry = await _context.RednessTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<RednessDTO>>.SuccessAsync(rednessEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<RednessDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
