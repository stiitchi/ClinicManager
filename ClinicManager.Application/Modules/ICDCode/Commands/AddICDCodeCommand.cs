using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities.ICDCodeAggregate;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ICDCode.Commands
{
     public class AddICDCodeCommand : IRequest<Result<int>>
    {
        public string ICDCode { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class AddICDCodeCommandHandler : IRequestHandler<AddICDCodeCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public AddICDCodeCommandHandler(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<int>> Handle(AddICDCodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var icdCodes = await _context.ICDCodes.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.IcdCode == request.ICDCode, cancellationToken);
                if (icdCodes != null)
                    throw new Exception("ICD Code already exists");

                var icdCode = new ICDCodeEntity(
                    request.ICDCode,
                    request.Description,
                    request.DateAdded
                    );

                await _context.ICDCodes.AddAsync(icdCode, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return await Result<int>.SuccessAsync(icdCode.Id);
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync(ex.Message);
            }
        }
    }
}
