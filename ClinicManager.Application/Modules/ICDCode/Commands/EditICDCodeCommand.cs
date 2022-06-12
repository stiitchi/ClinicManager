using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Application.Modules.ICDCode.Commands
{
        public class EditICDCodeCommand : IRequest<Result<int>>
        {
        public int Id { get; set; }
        public string ICDCode { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }

        public class EditICDCodeCommandHandler : IRequestHandler<EditICDCodeCommand, Result<int>>
        {
            private readonly IApplicationDbContext _context;

            public EditICDCodeCommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Result<int>> Handle(EditICDCodeCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var icdCode = await _context.ICDCodes.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                    if (icdCode == null)
                        throw new Exception("ICD Code does not exist");

                    icdCode.Set(
                    request.ICDCode,
                    request.Description,
                    request.DateAdded
                        );
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
