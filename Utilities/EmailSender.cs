using Microsoft.AspNetCore.Identity.UI.Services;

namespace Utilities;

public class EmailSender : IEmailSender
{
    // TODO: SEND EMAIL
    public Task SendEmailAsync(string email, string subject, string htmlMessage) =>
         Task.CompletedTask;
    
}