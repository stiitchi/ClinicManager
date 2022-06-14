using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Commands
{
  public class AddContinentCommand : IRequest<Result<int>>
    {
        public DateTime ContinentTime { get; set; }
        public int ContinentFreq { get; set; }
        public string ContinentSignature { get; set; }
        public int PatientId { get; set; }
        public int ContinentId { get; set; }

    }

    public class AddContinentCommandHandler : IRequestHandler<AddContinentCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddContinentCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddContinentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var continentEntry = await _context.ContinentRecords.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.ContinentId, cancellationToken);
                if (continentEntry != null)
                    throw new Exception("Continent Entry already exists");

                var patient = await _context.Patients.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var continentRecord = new ContinentEntity(
                    request.ContinentTime,
                    request.ContinentFreq,
                    request.ContinentSignature,
                    patient
                    );

                await _context.ContinentRecords.AddAsync(continentRecord, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(continentRecord.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
