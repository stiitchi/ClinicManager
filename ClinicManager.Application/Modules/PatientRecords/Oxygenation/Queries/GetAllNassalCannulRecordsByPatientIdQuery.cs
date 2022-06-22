using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.DTO_s.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
    public class GetAllNassalCannulRecordsByPatientIdQuery : IRequest<Result<List<NasalCannulaDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllNassalCannulRecordsByPatientIdQueryHandler : IRequestHandler<GetAllNassalCannulRecordsByPatientIdQuery, Result<List<NasalCannulaDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNassalCannulRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<NasalCannulaDTO>>> Handle(GetAllNassalCannulRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<NasalCannulEntity, NasalCannulaDTO>> expression = e => new NasalCannulaDTO
                {
                    NasalCannulaId = e.Id,
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
                return await Result<List<NasalCannulaDTO>>.SuccessAsync(nasalEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<NasalCannulaDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
