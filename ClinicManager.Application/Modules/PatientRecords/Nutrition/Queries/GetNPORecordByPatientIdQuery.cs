using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Nutrition;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{
   public class GetNPORecordByPatientIdQuery : IRequest<Result<KeepNPODTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetNPORecordByPatientIdQueryHandler : IRequestHandler<GetNPORecordByPatientIdQuery, Result<KeepNPODTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetNPORecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<KeepNPODTO>> Handle(GetNPORecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var npoRecordEntry = await _context.KeepNPOTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.KeepNPOFrequency != 0,
                    cancellationToken);
                if (npoRecordEntry == null)
                    throw new Exception("Unable to return NPO Record");

                var dto = new KeepNPODTO
                {
                    KeepNPOFrequency = npoRecordEntry.KeepNPOFrequency,
                    KeepNPOSignature = npoRecordEntry.KeepNPOSignature,
                    KeepNPOTime = npoRecordEntry.KeepNPOTime,
                    PatientId = npoRecordEntry.PatientId
                };
                return await Result<KeepNPODTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<KeepNPODTO>.FailAsync(ex.Message);
            }
        }
    }
}

