namespace UniNote.Core.Models;

public record EmailPayloadAttachment(byte[] File, string Name, string MediaType, string SubType);

public record EmailPayload
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    
    public List<EmailPayloadAttachment> Attachments { get; set; } = new();

    public EmailPayload(string toEmail, string subject, string body, List<EmailPayloadAttachment>? attachments = null)
    {
        ToEmail = toEmail;
        Subject = subject;
        Body = body;
        if (attachments != null) Attachments = attachments;
    }

    public override string ToString()
        => $"To: {ToEmail}, Subject: {Subject}, {Body}";
}