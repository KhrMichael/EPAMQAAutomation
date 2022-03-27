using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuIncomingMailPageException : MailRuException
{
    public MailRuIncomingMailPageException()
    {
    }

    protected MailRuIncomingMailPageException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuIncomingMailPageException(string? message) : base(message)
    {
    }

    public MailRuIncomingMailPageException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}