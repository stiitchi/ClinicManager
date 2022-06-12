using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
    public class GetAllByMobilityRecordsByPatientIdQuery : IRequest<Result<List<MobilityRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllByMobilityRecordsByPatientIdQueryHandler : IRequestHandler<GetAllByMobilityRecordsByPatientIdQuery, Result<List<MobilityRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllByMobilityRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<MobilityRecordDTO>>> Handle(GetAllByMobilityRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<MobileImmobileEntity, MobilityRecordDTO>> expression = e => new MobilityRecordDTO
                {
                    MobileImmobileTime = e.MobileImmobileTime,
                    MobileImmobileFreq = e.MobileImmobileFrequency,
                    MobileImmobileSignature = e.MobileImmobileSignature,
                    PatientId = e.PatientId
                };

                var mobilityRecord = await _context.MobileImmobileTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.MobileImmobileFreq != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<MobilityRecordDTO>>.SuccessAsync(mobilityRecord);

            }
            catch (Exception ex)
            {
                return await Result<List<MobilityRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
