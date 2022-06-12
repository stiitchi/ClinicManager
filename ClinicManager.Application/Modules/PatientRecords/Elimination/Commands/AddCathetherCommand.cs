using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Elimination.Commands
{
   public class AddCathetherCommand : IRequest<Result<int>>
    {
        public DateTime CatheterTime { get; set; }
        public int CatheterFreq { get; set; }
        public string CatheterSignature { get; set; }
        public int CatheterPatientId { get; set; }
        public int EliminationRecordId { get; set; }

    }

    public class AddCathetherCommandHandler : IRequestHandler<AddCathetherCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddCathetherCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddCathetherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cathetherEntry = await _context.CathetherRecords.IgnoreQueryFilters()
                                                 .FirstOrDefaultAsync(c => c.Id == request.EliminationRecordId, cancellationToken);
                if (cathetherEntry != null)
                    throw new Exception("Cathether Entry already exists");

                var patient = await _context.Patients.IgnoreQueryFilters()
                                               .FirstOrDefaultAsync(c => c.Id == request.CatheterPatientId, cancellationToken);
                if (patient == null)
                    throw new Exception("Patient doesn't exist");

                var cathetherRecord = new CathetherEntity(
                    request.CatheterTime,
                    request.CatheterFreq,
                    request.CatheterSignature,
                    patient
                    );

                await _context.CathetherRecords.AddAsync(cathetherRecord, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(cathetherRecord.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
