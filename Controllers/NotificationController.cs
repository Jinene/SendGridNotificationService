using Microsoft.AspNetCore.Mvc;
using SendGridNotificationService.Models;
using SendGridNotificationService.Services;

namespace SendGridNotificationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly IEmailService _emailService;

    public NotificationController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
    {
        await _emailService.SendEmailAsync(
            request.To,
            request.Subject,
            request.Message
        );

        return Ok("Email sent successfully.");
    }
}
