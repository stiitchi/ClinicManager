using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
    public class GetNassalCannulByPatientIdQuery : IRequest<Result<List<OxygenationRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetNassalCannulByPatientIdQueryHandler : IRequestHandler<GetNassalCannulByPatientIdQuery, Result<List<OxygenationRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetNassalCannulByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<OxygenationRecordDTO>>> Handle(GetNassalCannulByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<NasalCannulEntity, OxygenationRecordDTO>> expression = e => new OxygenationRecordDTO
                {
                    NasalCannulaFrequency = e.NasalCannulaFrequency,
                    NasalCannulaSignature = e.NasalCannulaSignature,
                    NasalCannulaTime = e.NasalCannulaTime,
                    PatientId = e.PatientId
                };

                var nasalEntry = await _context.NasalCannulTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.NasalCannulaFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<OxygenationRecordDTO>>.SuccessAsync(nasalEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<OxygenationRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
