using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Records.Observations;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Observation.Queries
{
     public class GetNeuroVascularRecordByPatientIdQuery : IRequest<Result<NeuroVascularDTO>>
    {
        public int PatientId { get; set; }
    }

    public class GetNeuroVascularRecordByPatientIdQueryHandler : IRequestHandler<GetNeuroVascularRecordByPatientIdQuery, Result<NeuroVascularDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetNeuroVascularRecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<NeuroVascularDTO>> Handle(GetNeuroVascularRecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var neuroVascularRecord = await _context.NeurovascularTests.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.NeuroVascularFrequency != 0,
                    cancellationToken);
                if (neuroVascularRecord == null)
                    throw new Exception("Unable to return Neuro Vascular Record");

                var dto = new NeuroVascularDTO
                {
                    NeuroVascularTime = neuroVascularRecord.NeuroVascularTime,
                    NeuroVascularSignature = neuroVascularRecord.NeuroVascularSignature,
                    NeuroVascularFrequency = neuroVascularRecord.NeuroVascularFrequency,
                    PatientId = neuroVascularRecord.PatientId
                };
                return await Result<NeuroVascularDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<NeuroVascularDTO>.FailAsync(ex.Message);
            }
        }
    }
}
