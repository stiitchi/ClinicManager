using ClinicManager.Application.Interfaces.Services;
using ClinicManager.Infrastructure.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ClinicManager.Infrastructure.Persistence.Services
{
    public class SendGridService : ISendGridService
    {
        private SendGridClient _client;
        private readonly SendGridSettings _emailSettings;
        private List<EmailAddress> _recipients;
        private readonly ILogger<SendGridService> _logger;

        public SendGridService(IOptions<SendGridSettings> emailSettings, ILogger<SendGridService> logger)
        {
            _emailSettings = emailSettings.Value;
            _client = new SendGridClient(_emailSettings.ApiKey);
            _recipients = new List<EmailAddress>();
            _logger = logger;
        }

        public async Task<bool> SendEmail(object emailDataTemplate, string templateId)
        {
            try
            {
                var from = new EmailAddress(_emailSettings.EmailFrom, _emailSettings.EmailFromName);


                foreach(var recipient in _recipients)
                {
                    var msg =  MailHelper.CreateSingleTemplateEmail(from, recipient, templateId, emailDataTemplate);
                    var response = await _client.SendEmailAsync(msg);
                    return response.StatusCode == System.Net.HttpStatusCode.Accepted;
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Could not send email - {e.Message}");
                throw;
            }
            return false;
        }

        public void AddRecipient(EmailAddress recipient)
        {
            _recipients.Add(recipient);
        }
    }
}
