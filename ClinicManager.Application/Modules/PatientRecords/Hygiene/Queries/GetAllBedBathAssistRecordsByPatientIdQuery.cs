using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Shared.DTO_s.Records.Hygiene;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Hygiene.Queries
{
     public class GetAllBedBathAssistRecordsByPatientIdQuery : IRequest<Result<List<BedBathAssistDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllBedBathAssistRecordsByPatientIdQueryHandler : IRequestHandler<GetAllBedBathAssistRecordsByPatientIdQuery, Result<List<BedBathAssistDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBedBathAssistRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<BedBathAssistDTO>>> Handle(GetAllBedBathAssistRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<BedBathAssistEntity, BedBathAssistDTO>> expression = e => new BedBathAssistDTO
                {
                    BedBathAssistId        = e.Id,
                    BedBathAssistTime      = e.BedBathAssistTime,
                    BedBathAssistFreq      = e.BedBathAssistFrequency,
                    BedBathAssistSignature = e.BedBathAssistSignature,
                    PatientId              = e.PatientId
                };

                var bedBath = await _context.BedBathAssistTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<BedBathAssistDTO>>.SuccessAsync(bedBath);

            }
            catch (Exception ex)
            {
                return await Result<List<BedBathAssistDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
