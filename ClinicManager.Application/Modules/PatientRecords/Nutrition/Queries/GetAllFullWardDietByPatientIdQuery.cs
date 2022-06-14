using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using ClinicManager.Shared.DTO_s.Records.Nutrition;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{
    public class GetAllFullWardDietByPatientIdQuery : IRequest<Result<List<FullWardDietDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllFullWardDietByPatientIdQueryHandler : IRequestHandler<GetAllFullWardDietByPatientIdQuery, Result<List<FullWardDietDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllFullWardDietByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<FullWardDietDTO>>> Handle(GetAllFullWardDietByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<WardDietEntity, FullWardDietDTO>> expression = e => new FullWardDietDTO
                {
                    FullWardDietTime = e.FullWardDietTime,
                    FullWardDietFrequency = e.FullWardDietFrequency,
                    FullWardDietSignature = e.FullWardDietSignature,
                    PatientId = e.PatientId
                };

                var wardDietEntry = await _context.WardDietTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<FullWardDietDTO>>.SuccessAsync(wardDietEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<FullWardDietDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}