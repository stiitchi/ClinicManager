using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Allergies;
using ClinicManager.Shared.DTO_s.Patients;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClinicManager.Application.Modules.PatientAllergies.Queries
{
    public class GetAllAllergiesByPatientIdQuery : IRequest<Result<List<AllergyDTO>>>
    {
        public int PatientId { get; set; }
    }

    public class GetAllAllergiesByPatientIdQueryHandler : IRequestHandler<GetAllAllergiesByPatientIdQuery, Result<List<AllergyDTO>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAllergiesByPatientIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<List<AllergyDTO>>> Handle(GetAllAllergiesByPatientIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientAllergiesEntity, AllergyDTO>> expression = e => new AllergyDTO
                {
                    AllergyId = e.Id,
                    Description = e.Description,
                    PatientId = e.PatientId
                };

                var allergies = await _context.PatientAllergies
                        .AsNoTracking()
                        .IgnoreQueryFilters()
                        .Where(x => x.PatientId == request.PatientId)
                        .Select(expression)
                        .ToListAsync(cancellationToken);
                return await Result<List<AllergyDTO>>.SuccessAsync(allergies);

            }
            catch (Exception ex)
            {
                return await Result<List<AllergyDTO>>.FailAsync(new List<string> { ex.Message });
            }
        }
    }
}
