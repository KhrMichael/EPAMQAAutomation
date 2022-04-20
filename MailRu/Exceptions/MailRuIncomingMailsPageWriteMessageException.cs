using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuIncomingMailsPageWriteMessageException : MailRuIncomingMailPageException
{
    public MailRuIncomingMailsPageWriteMessageException()
    {
    }

    protected MailRuIncomingMailsPageWriteMessageException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuIncomingMailsPageWriteMessageException(string? message) : base(message)
    {
    }

    public MailRuIncomingMailsPageWriteMessageException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}