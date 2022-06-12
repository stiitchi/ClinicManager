using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetNeuroVascularRecordByPatientIdQuery : IRequest<Result<ObservationRecordDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetNeuroVascularRecordByPatientIdQueryHandler : IRequestHandler<GetNeuroVascularRecordByPatientIdQuery, Result<ObservationRecordDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetNeuroVascularRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<ObservationRecordDTO>> Handle(GetNeuroVascularRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var neuroVascularRecord = await _context.NeurovascularTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.NeuroVascularFrequency != 0,
                    cancellationToken);
                if (neuroVascularRecord == null)
                    throw new Exception("Unable to return Neuro Vascular Record");

                var dto = new ObservationRecordDTO
                {
                    NeuroVascularTime = neuroVascularRecord.NeuroVascularTime,
                    NeuroVascularSignature = neuroVascularRecord.NeuroVascularSignature,
                    NeuroVascularFrequency = neuroVascularRecord.NeuroVascularFrequency,
                    PatientId = neuroVascularRecord.PatientId
                };
                return await Result<ObservationRecordDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<ObservationRecordDTO>.FailAsync(ex.Message);
            }
        }
    }
}
