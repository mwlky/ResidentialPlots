using Microsoft.AspNetCore.Identity.UI.Services;

namespace Utilities;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Due to privacy, I decided to not showing the email sending logic
        return Task.CompletedTask;
    }
    
}