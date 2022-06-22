using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Nutrition;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{
    public class GetFullWardDietByPatientIdQuery : IRequest<Result<FullWardDietDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetFullWardDietByPatientIdQueryHandler : IRequestHandler<GetFullWardDietByPatientIdQuery, Result<FullWardDietDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetFullWardDietByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<FullWardDietDTO>> Handle(GetFullWardDietByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var fullWardEntry = await _context.WardDietTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId);
                if (fullWardEntry == null)
                    throw new Exception("Unable to return Full Ward Diet Record");

                var dto = new FullWardDietDTO
                {
                    FullWardDietID = fullWardEntry.Id,
                    FullWardDietFrequency = fullWardEntry.FullWardDietFrequency,
                    FullWardDietSignature = fullWardEntry.FullWardDietSignature,
                    FullWardDietTime = fullWardEntry.FullWardDietTime,
                    PatientId = fullWardEntry.PatientId
                };
                return await Result<FullWardDietDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<FullWardDietDTO>.FailAsync(ex.Message);
            }
        }
    }
}
