using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.Oxygenation.Commands
{
    public class AddNasalCannulCommand : IRequest<Result<int>>
    {
        public DateTime NasalCannulaTime { get; set; }
        public int NasalCannulaFrequency { get; set; }
        public int NasalCannulaId { get; set; }
        public string NasalCannulaSignature { get; set; }
        public int PatientId { get; set; }


        public class AddNasalCannulCommandHandler : IRequestHandler<AddNasalCannulCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddNasalCannulCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddNasalCannulCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var nasalCannulRecord = await _context.NasalCannulTests.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.NasalCannulaId
                                                     ,cancellationToken);
                    if (nasalCannulRecord != null)
                        throw new Exception("Nasal Cannul Record already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var nasalCannulEntry = new NasalCannulEntity(
                        request.NasalCannulaTime,
                        request.NasalCannulaFrequency,
                        request.NasalCannulaSignature,
                        patient
                        );

                    await _context.NasalCannulTests.AddAsync(nasalCannulEntry, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(nasalCannulEntry.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
