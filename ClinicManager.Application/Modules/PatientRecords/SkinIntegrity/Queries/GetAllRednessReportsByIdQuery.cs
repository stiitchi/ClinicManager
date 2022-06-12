using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Queries
{
    public class GetAllRednessReportsByIdQuery : IRequest<Result<List<SkinIntegrityReportDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllRednessReportsByIdQueryHandler : IRequestHandler<GetAllRednessReportsByIdQuery, Result<List<SkinIntegrityReportDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllRednessReportsByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<SkinIntegrityReportDTO>>> Handle(GetAllRednessReportsByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PressurePartEntity, SkinIntegrityReportDTO>> expression = e => new SkinIntegrityReportDTO
                {
                    PressurePartCareFrequency = e.PressurePartCareFrequency,
                    PressurePartCareSignature = e.PressurePartCareSignature,
                    PressurePartCareTime = e.PressurePartCareTime,
                    PatientId = e.PatientId
                };

                var rednessEntry = await _context.PressurePartRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.ReportRednessFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<SkinIntegrityReportDTO>>.SuccessAsync(rednessEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<SkinIntegrityReportDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
