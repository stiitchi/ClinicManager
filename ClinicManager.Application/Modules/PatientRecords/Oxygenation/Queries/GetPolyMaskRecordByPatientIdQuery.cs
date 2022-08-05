using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
   public class GetPolyMaskRecordByPatientIdQuery : IRequest<Result<PolyMaskDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetPolyMaskRecordByPatientIdQueryHandler : IRequestHandler<GetPolyMaskRecordByPatientIdQuery, Result<PolyMaskDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetPolyMaskRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<PolyMaskDTO>> Handle(GetPolyMaskRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var polyMaskEntry = await _context.PolyMaskTests.AsNoTracking()
                  .IgnoreQueryFilters()
                  .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (polyMaskEntry == null)
                    throw new Exception("Unable to return Urine Test");

                var dto = new PolyMaskDTO
                {
                    PolyMaskId          = polyMaskEntry.Id,
                    PolyMaskFrequency   = polyMaskEntry.PolyMaskFrequency,
                    PolyMaskSignature   = polyMaskEntry.PolyMaskSignature,
                    PolyMaskTime        = polyMaskEntry.PolyMaskTime,
                    PatientId           = polyMaskEntry.PatientId
                };
                return await Result<PolyMaskDTO>.SuccessAsync(dto);

            }
            catch (Exception ex)
            {
                return await Result<PolyMaskDTO>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
