using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
    public class GetMaskRecordByPatientIdQuery : IRequest<Result<MaskDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetMaskRecordByPatientIdQueryHandler : IRequestHandler<GetMaskRecordByPatientIdQuery, Result<MaskDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetMaskRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<MaskDTO>> Handle(GetMaskRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var maskEntry = await _context.MaskTimeTests.AsNoTracking()
                   .IgnoreQueryFilters()
                   .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (maskEntry == null)
                    throw new Exception("Unable to return Mask Entry");

                var dto = new MaskDTO
                {
                    MaskId          = maskEntry.Id,
                    MaskFrequency   = maskEntry.MaskFrequency,
                    MaskTime        = maskEntry.MaskTime,
                    PatientId       = maskEntry.PatientId,
                    MaskSignature   = maskEntry.MaskSignature
                };

                return await Result<MaskDTO>.SuccessAsync(dto);

            }
            catch (Exception ex)
            {
                return await Result<MaskDTO>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
