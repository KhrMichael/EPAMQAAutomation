using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuIncomingMailsPageClickOnProfileButtonException : MailRuIncomingMailPageException
{
    public MailRuIncomingMailsPageClickOnProfileButtonException()
    {
    }

    protected MailRuIncomingMailsPageClickOnProfileButtonException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuIncomingMailsPageClickOnProfileButtonException(string? message) : base(message)
    {
    }

    public MailRuIncomingMailsPageClickOnProfileButtonException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}