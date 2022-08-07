using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using ClinicManager.Shared.DTO_s.Records.Safety;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Queries
{
     public class GetAllCotsideRecordsByPatientIdQuery : IRequest<Result<List<CotsideDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllCotsideRecordsByPatientIdQueryHandler : IRequestHandler<GetAllCotsideRecordsByPatientIdQuery, Result<List<CotsideDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllCotsideRecordsByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<CotsideDTO>>> Handle(GetAllCotsideRecordsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<CotsideEntity, CotsideDTO>> expression = e => new CotsideDTO
                {
                    CotsidesId          = e.Id,
                    CotsidesFrequency   = e.CotsidesFrequency,
                    CotsidesSignature   = e.CotsidesSignature,
                    CotsidesTime        = e.CotsidesTime,
                    PatientId           = e.PatientId
                };

                var cotsideEntry = await _context.CotsideRecords
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .OrderByDescending(x => x.CotsidesTime)
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.CotsidesFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<CotsideDTO>>.SuccessAsync(cotsideEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<CotsideDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
