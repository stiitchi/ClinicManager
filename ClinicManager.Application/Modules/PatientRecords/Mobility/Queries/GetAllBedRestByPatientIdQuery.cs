using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
     public class GetAllBedRestByPatientIdQuery : IRequest<Result<List<MobilityRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllBedRestByPatientIdQueryHandler : IRequestHandler<GetAllBedRestByPatientIdQuery, Result<List<MobilityRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBedRestByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<MobilityRecordDTO>>> Handle(GetAllBedRestByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BedRestEntity, MobilityRecordDTO>> expression = e => new MobilityRecordDTO
                {
                    BedRestTime = e.BedRestTime,
                    BedRestFrequency = e.BedRestFrequency,
                    BedRestSignature = e.BedRestSignature,
                    PatientId = e.PatientId
                };

                var bedRest = await _context.BedRestTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.BedRestFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<MobilityRecordDTO>>.SuccessAsync(bedRest);

            }
            catch (Exception ex)
            {
                return await Result<List<MobilityRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
