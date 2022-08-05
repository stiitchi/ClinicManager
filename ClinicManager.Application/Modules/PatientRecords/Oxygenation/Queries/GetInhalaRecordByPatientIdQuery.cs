using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
    public class GetInhalaRecordByPatientIdQuery : IRequest<Result<InhalaNebsDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetInhalaRecordByPatientIdQueryHandler : IRequestHandler<GetInhalaRecordByPatientIdQuery, Result<InhalaNebsDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetInhalaRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<InhalaNebsDTO>> Handle(GetInhalaRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var inhalaRecord = await _context.InhalaNebsTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (inhalaRecord == null)
                    throw new Exception("Unable to return Inhala Test");

                var dto = new InhalaNebsDTO
                {
                    InhalaNebsId         = inhalaRecord.Id,
                    InhalaNebsFrequency  = inhalaRecord.InhalaNebsFrequency,
                    InhalaNebsSignature  = inhalaRecord.InhalaNebsSignature,
                    InhalaNebsTime       = inhalaRecord.InhalaNebsTime,
                    PatientId            = inhalaRecord.PatientId
                };
                return await Result<InhalaNebsDTO>.SuccessAsync(dto);

            }
            catch (Exception ex)
            {
                return await Result<InhalaNebsDTO>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
