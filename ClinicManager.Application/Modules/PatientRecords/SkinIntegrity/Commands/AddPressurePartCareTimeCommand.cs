using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.PatientRecords.SkinIntegrity.Commands
{
    public class AddPressurePartCareTimeCommand : IRequest<Result<int>>
    {
        public DateTime PressurePartCareTime { get; set; }
        public int PressurePartCareFrequency { get; set; }
        public int PressurePartCareId { get; set; }
        public string PressurePartCareSignature { get; set; }
        public int PatientId { get; set; }


        public class AddPressurePartCareTimeCommandHandler : IRequestHandler<AddPressurePartCareTimeCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public AddPressurePartCareTimeCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(AddPressurePartCareTimeCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var pressureCarePartEntry = await _context.SkinIntegrityReports.IgnoreQueryFilters()
                                                     .FirstOrDefaultAsync(c => c.PatientId == request.PatientId && c.Id == request.PressurePartCareId
                                                     ,cancellationToken);
                    if (pressureCarePartEntry != null)
                        throw new Exception("Pressure Part Care already exists");

                    var patient = await _context.Patients.IgnoreQueryFilters()
                                                   .FirstOrDefaultAsync(c => c.Id == request.PatientId, cancellationToken);
                    if (patient == null)
                        throw new Exception("Patient doesn't exist");

                    var pressure = new PressurePartEntity(
                        request.PressurePartCareTime,
                        request.PressurePartCareFrequency,
                        request.PressurePartCareSignature,
                        patient
                        );

                    await _context.PressurePartRecords.AddAsync(pressure, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(pressure.Id);
                }
                catch (Exception ex)
                {
                    return await Result<int>.FailAsync(ex.Message);
                }
            }
        }
    }
}
