using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Shared.DTO_s.Records.Hygiene;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries
{
    public class GetAllBedBathRecordByPatientIdQuery : IRequest<Result<List<BedBathDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllBedBathRecordByPatientIdQueryHandler : IRequestHandler<GetAllBedBathRecordByPatientIdQuery, Result<List<BedBathDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBedBathRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BedBathDTO>>> Handle(GetAllBedBathRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BedBathEntity, BedBathDTO>> expression = e => new BedBathDTO
                {
                    BedBathId        = e.Id,
                    BedBathTime      = e.BedBathTime,
                    BedBathFreq      = e.BedBathFrequency,
                    BedBathSignature = e.BedBathSignature,
                    PatientId        = e.PatientId
                };

                var bedBathReport = await _context.BedBathTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .OrderByDescending(x => x.BedBathTime)
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<BedBathDTO>>.SuccessAsync(bedBathReport);

            }
            catch (Exception ex)
            {
                return await Result<List<BedBathDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
