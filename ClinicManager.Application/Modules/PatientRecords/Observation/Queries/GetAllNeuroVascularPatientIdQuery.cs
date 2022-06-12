using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
    public class GetAllNeuroVascularPatientIdQuery : IRequest<Result<List<ObservationRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllNeuroVascularPatientIdQueryHandler : IRequestHandler<GetAllNeuroVascularPatientIdQuery, Result<List<ObservationRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNeuroVascularPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<ObservationRecordDTO>>> Handle(GetAllNeuroVascularPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<NeurovascularEntity, ObservationRecordDTO>> expression = e => new ObservationRecordDTO
                {
                    NeuroVascularTime = e.NeuroVascularTime,
                    NeuroVascularSignature = e.NeuroVascularSignature,
                    NeuroVascularFrequency = e.NeuroVascularFrequency,
                    PatientId = e.PatientId
                };

                var neuroVascularEntry = await _context.NeurovascularTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.NeuroVascularFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<ObservationRecordDTO>>.SuccessAsync(neuroVascularEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<ObservationRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
