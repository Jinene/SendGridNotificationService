using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGridNotificationService.Models;

namespace SendGridNotificationService.Services;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string message);
}

public class EmailService : IEmailService
{
    private readonly SendGridSettings _settings;

    public EmailService(IOptions<SendGridSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task SendEmailAsync(string to, string subject, string message)
    {
        var client = new SendGridClient(_settings.ApiKey);
        var from = new EmailAddress(_settings.FromEmail, _settings.FromName);
        var toEmail = new EmailAddress(to);

        var email = MailHelper.CreateSingleEmail(
            from,
            toEmail,
            subject,
            message,
            message
        );

        await client.SendEmailAsync(email);
    }
}
