using System.Runtime.Serialization;

namespace MailRu.Exceptions;

public class MailRuIncomingMailsPageSendMessageException : MailRuIncomingMailPageException
{
    public MailRuIncomingMailsPageSendMessageException()
    {
    }

    protected MailRuIncomingMailsPageSendMessageException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MailRuIncomingMailsPageSendMessageException(string? message) : base(message)
    {
    }

    public MailRuIncomingMailsPageSendMessageException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}