using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Mobility.Queries
{
     public class GetAllWalkAssistanceRecordsByPatientIdQuery : IRequest<Result<List<MobilityRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllWalkAssistanceRecordsByPatientIdQueryHandler : IRequestHandler<GetAllWalkAssistanceRecordsByPatientIdQuery, Result<List<MobilityRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllWalkAssistanceRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<MobilityRecordDTO>>> Handle(GetAllWalkAssistanceRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<WalkAssistanceEntity, MobilityRecordDTO>> expression = e => new MobilityRecordDTO
                {
                    WalkWithAssistanceTime = e.WalkWithAssistanceTime,
                    WalkWithAssistanceFrequency = e.WalkWithAssistanceFrequency,
                    WalkWithAssistanceSignature = e.WalkWithAssistanceSignature,
                    PatientId = e.PatientId
                };

                var bedRest = await _context.WalkAssistanceTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.WalkWithAssistanceFrequency != 0)
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
