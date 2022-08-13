using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s.Patients;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientAllergies.Queries
{
    public class GetAlleryByIdQuery : IRequest<Result<AllergyDTO>>
    {
        public int Id { get; set; }
    }

    public class GetAlleryByIdQueryHandler : IRequestHandler<GetAlleryByIdQuery, Result<AllergyDTO>>
    {
        private readonly IApplicationDbContext _context;

        public GetAlleryByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<AllergyDTO>> Handle(GetAlleryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allergy = await _context.PatientAllergies.AsNoTracking()
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (allergy == null)
                    throw new Exception("Unable to return Allergy");

                var dto = new AllergyDTO
                {
                    AllergyId   = allergy.Id,
                    Description = allergy.Description,
                    PatientId   = allergy.PatientId
                };
                return await Result<AllergyDTO>.SuccessAsync(dto);
            }
            catch (Exception ex)
            {
                return await Result<AllergyDTO>.FailAsync(ex.Message);
            }
        }
    }
}
