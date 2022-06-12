using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries
{
    public class GetAllBedBathRecordByPatientIdQuery : IRequest<Result<List<HygieneDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllBedBathRecordByPatientIdQueryHandler : IRequestHandler<GetAllBedBathRecordByPatientIdQuery, Result<List<HygieneDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBedBathRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<HygieneDTO>>> Handle(GetAllBedBathRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BedBathEntity, HygieneDTO>> expression = e => new HygieneDTO
                {
                    BedBathTime = e.BedBathTime,
                    BedBathFreq= e.BedBathFrequency,
                    BedBathSignature = e.BedBathSignature,
                    PatientId = e.PatientId
                };

                var bedBathReport = await _context.BedBathTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.BedBathFreq != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<HygieneDTO>>.SuccessAsync(bedBathReport);

            }
            catch (Exception ex)
            {
                return await Result<List<HygieneDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
