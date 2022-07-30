//using ClinicManager.Shared.DTO_s;
//using ClinicManager.Shared.Wrappers;
//using MediatR;

//namespace ClinicManager.Application.Modules.User.Commands
//{
//    public class RegisterClientEmailCommand : IRequest<IResult<bool>>
//    {
//        public RegisterEmailDTO _dto { get; set; }
//        public RegisterClientEmailCommand(RegisterEmailDTO dto)
//        {
//            _dto = dto;
//        }
//    }
//    public class RegisterClientEmailCommandHandler : IRequestHandler<RegisterClientEmailCommand, IResult<bool>>
//    {

//        private readonly ISendGridService _emailService;
//        private readonly IApplicationDbContext _context;

//        public RegisterClientEmailCommandHandler(/*ISendGridService emailService, */IApplicationDbContext dbService)
//        {
//            _emailService =
//                emailService ?? throw new ArgumentNullException(nameof(emailService));
//            _context = dbService ?? throw new ArgumentNullException(nameof(dbService));
//        }

//        public async Task<IResult<bool>> Handle(RegisterClientEmailCommand request, CancellationToken cancellationToken)
//        {
//            try
//            {

//                var user = _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Email.ToLower() == request._dto.Email.ToLower(), cancellationToken).Result;

//                if (user == null)
//                {
//                    return await Result<bool>.FailAsync("No user with that email address found");
//                }

//                object emailTemplate = new { };
//                var templateId = "";

//                templateId = request._dto.EmailTemplateId;

//                _emailService.AddRecipient(new EmailAddress()
//                {
//                    Email = request._dto.Email,
//                    Name = $"{user.FirstName} {user.LastName}"
//                });

//                string resetCode = Guid.NewGuid().ToString();

//                user.SetPasswordReset(resetCode, DateTime.Now.AddMinutes(60));
//                await _context.SaveChangesAsync(cancellationToken);

//                var verifyUrl = "activate-account/" + resetCode;
//                var link = request._dto.Url + verifyUrl;

//                emailTemplate = new ActivationEmailTemplate()
//                {
//                    Fullname = $"{user.FirstName} {user.LastName}",
//                    Link = link
//                };

//                var result = await _emailService.SendEmail(emailTemplate, templateId.ToString());

//                return await Result<bool>.SuccessAsync();
//            }
//            catch (Exception e)
//            {
//                return await Result<bool>.FailAsync();
//            }
//        }
//    }
//}
