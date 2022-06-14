using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Shared.DTO_s.Records.Psychological;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Queries
{
    public class GetSupportRecordByPatientIdQuery : IRequest<Result<List<SupportDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetSupportRecordByPatientIdQueryHandler : IRequestHandler<GetSupportRecordByPatientIdQuery, Result<List<SupportDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetSupportRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<SupportDTO>>> Handle(GetSupportRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<SupportEntity, SupportDTO>> expression = e => new SupportDTO
                {
                    SupportTime = e.SupportTime,
                    SupportFrequency = e.SupportFrequency,
                    SupportSignature = e.SupportSignature,
                    PatientId = e.PatientId
                };

                var supportEntry = await _context.SupportTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.SupportFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<SupportDTO>>.SuccessAsync(supportEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<SupportDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
