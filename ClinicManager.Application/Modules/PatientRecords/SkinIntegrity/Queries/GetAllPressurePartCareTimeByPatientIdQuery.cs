using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Queries
{
   public class GetAllPressurePartCareTimeByPatientIdQuery : IRequest<Result<List<SkinIntegrityReportDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllPressurePartCareTimeByPatientIdQueryHandler : IRequestHandler<GetAllPressurePartCareTimeByPatientIdQuery, Result<List<SkinIntegrityReportDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllPressurePartCareTimeByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<SkinIntegrityReportDTO>>> Handle(GetAllPressurePartCareTimeByPatientIdQuery request, CancellationToken cancellationToken)
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

                var pressureEntry = await _context.PressurePartRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.PressurePartCareFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<SkinIntegrityReportDTO>>.SuccessAsync(pressureEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<SkinIntegrityReportDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
