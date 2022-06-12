using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.DTO_s.Records;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
     public class GetAllInhalaByPatientIdQuery : IRequest<Result<List<OxygenationRecordDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllInhalaByPatientIdQueryHandler : IRequestHandler<GetAllInhalaByPatientIdQuery, Result<List<OxygenationRecordDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllInhalaByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<OxygenationRecordDTO>>> Handle(GetAllInhalaByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<InhalaNebsEntity, OxygenationRecordDTO>> expression = e => new OxygenationRecordDTO
                {
                    InhalaNebsFrequency = e.InhalaNebsFrequency,
                    InhalaNebsSignature = e.InhalaNebsSignature,
                    InhalaNebsTime = e.InhalaNebsTime,
                    PatientId = e.PatientId
                };

                var inhalaEntry = await _context.InhalaNebsTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.InhalaNebsFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<OxygenationRecordDTO>>.SuccessAsync(inhalaEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<OxygenationRecordDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
