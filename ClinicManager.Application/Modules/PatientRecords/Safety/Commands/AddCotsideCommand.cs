using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Safety.Commands
{
    public class AddCotsideCommand : IRequest<Result<int>>
    {
        public DateTime CotsidesTime { get; set; }
        public int CotsidesFrequency { get; set; }
        public string CotsidesSignature { get; set; }
        public int PatientId { get; set; }


        public class AddCotsideCommandHandler : IRequestHandler<AddCotsideCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddCotsideCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddCotsideCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var cotsideEntry = await _context.CotsideRecords.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId, cancellationToken);
                    if (cotsideEntry != null)
                        throw new Exception("Cotside Entry already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var cotsideRecord = new CotsideEntity(
                        request.CotsidesTime,
                        request.CotsidesFrequency,
                        request.CotsidesSignature,
                        patient
                        );

                    await _context.CotsideRecords.AddAsync(cotsideRecord, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(cotsideRecord.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
