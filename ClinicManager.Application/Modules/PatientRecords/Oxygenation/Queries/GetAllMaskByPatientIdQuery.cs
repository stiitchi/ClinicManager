using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.DTO_s.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Queries
{
    public class GetAllMaskByPatientIdQuery : IRequest<Result<List<MaskDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllMaskByPatientIdQueryHandler : IRequestHandler<GetAllMaskByPatientIdQuery, Result<List<MaskDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllMaskByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<MaskDTO>>> Handle(GetAllMaskByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<MaskTimeEntity, MaskDTO>> expression = e => new MaskDTO
                {
                    MaskId = e.Id,
                    MaskFrequency = e.MaskFrequency,
                    MaskSignature = e.MaskSignature,
                    MaskTime = e.MaskTime,
                    PatientId = e.PatientId
                };

                var maskEntry = await _context.MaskTimeTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId && r.MaskFrequency != 0)
                        .ToListAsync(cancellationToken);
                return await Result<List<MaskDTO>>.SuccessAsync(maskEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<MaskDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
