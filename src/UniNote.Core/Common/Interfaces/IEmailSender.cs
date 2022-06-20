using UniNote.Core.Models;

namespace UniNote.Core.Common.Interfaces;

public interface IEmailSender : IServicePerLifeTimeScope
{
    Task SendEmailAsync(EmailPayload email);
}