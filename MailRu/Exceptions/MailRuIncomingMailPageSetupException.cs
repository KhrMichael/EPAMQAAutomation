using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuIncomingMailPageSetupException : MailRuIncomingMailPageException
{
    public MailRuIncomingMailPageSetupException()
    {
    }

    protected MailRuIncomingMailPageSetupException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuIncomingMailPageSetupException(string? message) : base(message)
    {
    }

    public MailRuIncomingMailPageSetupException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}