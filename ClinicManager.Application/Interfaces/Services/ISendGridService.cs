using SendGrid.Helpers.Mail;

namespace ClinicManager.Application.Interfaces.Services
{
    public interface ISendGridService
    {
        Task<bool> SendEmail(object emailDataTemplate, string templateId);
        void AddRecipient(EmailAddress recipient);
    }
}
