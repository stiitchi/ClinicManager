using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Psychological;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Psychological.Queries
{
    public class GetSupportRecordByPatientIdQuery : IRequest<Result<SupportDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetSupportRecordByPatientIdQueryHandler : IRequestHandler<GetSupportRecordByPatientIdQuery, Result<SupportDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetSupportRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<SupportDTO>> Handle(GetSupportRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var supportRecord = await _context.SupportTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (supportRecord == null)
                    throw new Exception("Unable to return Support Record");

                var dto = new SupportDTO
                {
                    SupportId = supportRecord.Id,
                    SupportFrequency = supportRecord.SupportFrequency,
                    SupportSignature = supportRecord.SupportSignature,
                    SupportTime = supportRecord.SupportTime,
                    PatientId = supportRecord.PatientId
                };

                return await Result<SupportDTO>.SuccessAsync(dto);

            }
            catch (Exception ex)
            {
                return await Result<SupportDTO>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
