using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using ClinicManager.Shared.DTO_s.Records.Nutrition;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientRecords.Nutrition.Queries
{
    public class GetAllNPORecordByPatientIdQuery : IRequest<Result<List<KeepNPODTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllNPORecordByPatientIdQueryHandler : IRequestHandler<GetAllNPORecordByPatientIdQuery, Result<List<KeepNPODTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllNPORecordByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<KeepNPODTO>>> Handle(GetAllNPORecordByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<KeepNPOEntity, KeepNPODTO>> expression = e => new KeepNPODTO
                {
                    KeepNPOId            = e.Id,
                    KeepNPOTime          = e.KeepNPOTime,
                    KeepNPOFrequency     = e.KeepNPOFrequency,
                    KeepNPOSignature     = e.KeepNPOSignature,
                    PatientId            = e.PatientId
                };

                var npoEntry = await _context.KeepNPOTests
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Select(expression)
                        .Where(r => r.PatientId == request.PatientId)
                        .ToListAsync(cancellationToken);
                return await Result<List<KeepNPODTO>>.SuccessAsync(npoEntry);

            }
            catch (Exception ex)
            {
                return await Result<List<KeepNPODTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
