using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.FaultAggregate;
using ClinicManager.Shared.Constants;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.Faults.Commands
{
    public class AddFaultCommand : IRequest<Result<int>>
    {

        public int Id { get; set; }

        public FaultTypes FaultTypes { get; set; }

        public string Description { get; set; }

        public string Severity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime SeenOn { get; set; }

        public int UserId { get; set; }

        public bool IsResolved { get; set; }

    }

    public class AddFaultCommandHandler : IRequestHandler<AddFaultCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddFaultCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddFaultCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var faults = await _context.Faults.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                if (faults != null)
                    throw new Exception("Fault already exists");

                var user = await _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.UserId, cancellationToken);
                if (user == null)
                    throw new Exception("User doesn't exist");

                var fault = new FaultEntity(
                    request.FaultTypes.ToString(),
                    request.Description,
                    request.CreatedOn,
                    request.Severity,
                    user
                    );


                await _context.Faults.AddAsync(fault, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(fault.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
