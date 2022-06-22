using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
    public class GetNassalCannulByPatientIdQuery : IRequest<Result<NasalCannulaDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetNassalCannulByPatientIdQueryHandler : IRequestHandler<GetNassalCannulByPatientIdQuery, Result<NasalCannulaDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetNassalCannulByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<NasalCannulaDTO>> Handle(GetNassalCannulByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var nasalCannalRecord = await _context.NasalCannulTests.AsNoTracking()
                     .IgnoreQueryFilters()
                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (nasalCannalRecord == null)
                    throw new Exception("Unable to return Nasal Cannul Test");

                var dto = new NasalCannulaDTO
                {
                    NasalCannulaId = nasalCannalRecord.Id,
                    NasalCannulaFrequency = nasalCannalRecord.NasalCannulaFrequency,
                    NasalCannulaSignature = nasalCannalRecord.NasalCannulaSignature,
                    NasalCannulaTime = nasalCannalRecord.NasalCannulaTime,
                    PatientId = nasalCannalRecord.PatientId
                };
                return await Result<NasalCannulaDTO>.SuccessAsync(dto);

            }
            catch (Exception ex)
            {
                return await Result<NasalCannulaDTO>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
